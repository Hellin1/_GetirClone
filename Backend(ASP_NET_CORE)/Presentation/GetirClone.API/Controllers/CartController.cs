using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Features.CQRS.Commands.Cart;
using GetirClone.Application.Features.CQRS.Queries;
using GetirClone.Application.Interfaces;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace GetirClone.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CartController : BaseController
    {
        private readonly ITransactionManager _transactionManager;

        public CartController(ITransactionManager trManager)
        {
            _transactionManager = trManager;
        }


        [Route("GetById")]
        [HttpGet]
        public async Task<IActionResult> GetById()
        {
            var cart = await _transactionManager.SendQuery(new GetCartQuery(CustomerId));
            return Ok(cart);
        }


        [Route("AddToCart")]
        [HttpPost]
        public async Task<IActionResult> AddToCart(AddToCartCommand command)
        {
            command.CustomerId = CustomerId;
            await _transactionManager.SendCommand(command);
            return Ok();
        }

        [Route("RemoveFromCart")]
        [HttpDelete]
        public async Task<IActionResult> RemoveFromCart(RemoveFromCartCommand command)
        {
            command.CustomerId = CustomerId;
            await _transactionManager.SendCommand(command);
            return Ok();
        }

        [Route("EmptyCart")]
        [HttpPost]
        public async Task<IActionResult> EmptyCart(EmptyCartCommand command)
        {
            command.CustomerId = CustomerId;
            await _transactionManager.SendCommand(command);
            return Ok();
        }
    }
}
