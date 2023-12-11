using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;
using GetirClone.Persistance.Context;
using Microsoft.EntityFrameworkCore;

namespace GetirClone.Persistance.Repositories
{
    public class CartRepository : ICartRepository
    {
        private readonly GetirCloneContext _context;

        public CartRepository(GetirCloneContext context)
        {
            _context = context;
        }

        public async Task AddToCart(AddToCartCommand cmd, CancellationToken cancellationToken)
        {
            var product = await _context.Products.FindAsync(new object?[] { cmd.ProductId }, cancellationToken: cancellationToken);

            var cart = await _context.Carts.
                Where(c => c.CustomerId == cmd.CustomerId).
                Include(c => c.CartDiscountRelations).
                Include(c => c.ProductCarts).
                ThenInclude(pc => pc.Product).FirstOrDefaultAsync(cancellationToken);

            var productCart = await _context.ProductCarts.FirstOrDefaultAsync(x => x.ProductId == cmd.ProductId && x.CartId == cart.Id, cancellationToken);

            productCart ??= new ProductCart
            {
                ProductId = cmd.ProductId,
                CartId = cart.Id,
                Quantity = 1,
                //Note = cmd.Note
            };

            productCart.Quantity += cmd.Quantity;

            productCart.TotalPrice = (productCart.Quantity * product.Price) - product.ProductDiscountRelations?.Sum(pdr => pdr.Discount.Amount) ?? 0;


            if (cart.ProductCarts != null && cart.ProductCarts.Any())
            {
                cart.ProductCarts.Add(productCart);
                cart.TotalPrice = CalculateCartTotal(cart);
            }
            else
            {
                cart.ProductCarts = new List<ProductCart> { productCart };
                cart.TotalPrice = productCart.TotalPrice;
            }

            cart.TotalQuantity += cmd.Quantity;

        }


        public decimal CalculateCartTotal(Cart cart)
        {
            decimal totalPrice = 0;
            decimal cartRowDiscountTotal = 0;
            decimal cartDiscountsTotal = 0;

            foreach (var productCart in cart?.ProductCarts)
            {
                totalPrice += productCart.Product.Price * productCart.Quantity;

                cartRowDiscountTotal += productCart.ProductCartDiscounts?.Sum(pcd => pcd.Discount.Amount) ?? 0;
            }

            totalPrice -= cartRowDiscountTotal;
            foreach (var cartDiscounts in cart?.CartDiscountRelations)
            {
                cartDiscountsTotal += cartDiscounts.Discount.Amount;
            }

            totalPrice -= cartDiscountsTotal;
            return totalPrice;
        }

        public async Task RemoveFromCart(int productId, Guid customerId, CancellationToken cancellationToken)
        {
            var productCart = await _context.ProductCarts.Include(pc => pc.Cart).FirstOrDefaultAsync(pc => pc.ProductId == productId && pc.Cart.CustomerId == customerId, cancellationToken);

            if (productCart != null)
            {
                if (productCart.Quantity > 1)
                {
                    productCart.Quantity -= 1;
                }
                else
                {
                    _context.ProductCarts.Remove(productCart);
                }
                await _context.SaveChangesAsync();
            }
        }

        public async Task<Cart> GetCartIncludeAll(Guid customerId, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.Where(c => c.CustomerId == customerId).
                Include(c => c.CartDiscountRelations).
                Include(c => c.ProductCarts).
                ThenInclude(pc => pc.Product).
                FirstOrDefaultAsync(cancellationToken);

            return cart;
        }

        public async Task<Cart?> GetCartWithProducts(Guid customerId, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.
                Include(c => c.CartDiscountRelations).
                Include(c => c.ProductCarts).
                ThenInclude(pc => pc.Product).
                FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken);

            if (cart != null)
            {
                cart.TotalPrice = CalculateCartTotal(cart);
                return cart;
            }

            return null;
        }


        public async Task ClearCart(Guid customerId, CancellationToken cancellationToken)
        {
            var cart = await _context.Carts.
                Include(c => c.ProductCarts).
                FirstOrDefaultAsync(c => c.CustomerId == customerId, cancellationToken);


            cart.ProductCarts = null;
            cart.TotalPrice = 0;
            cart.TotalQuantity = 0;
            cart.BagPrice = 0;


            await _context.SaveChangesAsync();
        }

        public async Task<decimal> CalculateCartPrice(Cart cart, CancellationToken cancellationToken)
        {

            var productCartPrices = await _context.ProductCarts.
                Where(pc => pc.CartId == cart.Id).
                Include(pc => pc.Product).
                ThenInclude(p => p.ProductDiscountRelations).
                ThenInclude(pdr => pdr.Discount).
                ToListAsync(cancellationToken);

            decimal totalPrice = 0;
            foreach (var productCart in productCartPrices)
            {
                decimal productTotalDiscount = 0;
                decimal productRowTotalDiscount = 0;

                foreach (var productDiscount in productCart?.Product?.ProductDiscountRelations)
                {
                    productTotalDiscount += productDiscount.Discount.Amount;
                }
                foreach (var cartRowDiscount in productCart?.ProductCartDiscounts)
                {
                    productRowTotalDiscount += cartRowDiscount.Discount.Amount;
                }

                totalPrice += productCart.Product.Price - productTotalDiscount - productRowTotalDiscount;
            }

            decimal cartDiscounts = 0;
            foreach (var discountRlt in cart.CartDiscountRelations)
            {
                cartDiscounts += discountRlt.Discount.Amount;
            }

            totalPrice += cart.BagPrice;
            totalPrice -= cartDiscounts;

            return totalPrice;
        }
    }
}