using GetirClone.Domain.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace GetirClone.Persistance.Context
{
    public class GetirCloneContext : DbContext
    {
        public GetirCloneContext(DbContextOptions<GetirCloneContext> options) : base(options)
        {
        }

        public DbSet<Address> Addresses { get; set; }
        public DbSet<AddressImage> AddressImages { get; set; }
        public DbSet<AddressType> AddressTypes { get; set; }
        public DbSet<Cart> Carts { get; set; }
        public DbSet<CardType> CardTypes { get; set; }
        public DbSet<CartDiscountRelation> CartDiscountRelations { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<Discount> Discounts { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderItem> OrderItems { get; set; }
        public DbSet<PaymentCard> PaymentCards { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<Product> Products { get; set; }
        public DbSet<ProductCart> ProductCarts { get; set; }
        public DbSet<ProductDiscountRelation> ProductDiscountRelations { get; set; }
        public DbSet<ProductWishlist> ProductWishlists { get; set; }
        public DbSet<Shipment> Shipments { get; set; }
        public DbSet<ShipmentStates> ShipmentStates { get; set; }
        public DbSet<Wishlist> Wishlists { get; set; }

        public async override Task<int> SaveChangesAsync(CancellationToken cancellationToken = default)
        {

            var currentTime = DateTime.UtcNow;
            foreach (var entry in ChangeTracker.Entries())
            {
                if (entry.State == EntityState.Modified)
                {
                    var entityType = entry.Entity.GetType();
                    var tableName = entry.Metadata.GetTableName();
                    var columnNames = new List<string> { "LastUpdatedDate", "LastPrimaryDate" };

                    foreach (var columnName in columnNames)
                    {
                        // might be unefficient to run sql everytime for checking columns i  might  convert this to version withut iteration
                        var property = entityType.GetProperty(columnName);
                        if (property != null)
                        {
                            var checkColumnExistsSql = $@"
                            IF EXISTS (
                                SELECT 1 
                                FROM INFORMATION_SCHEMA.COLUMNS 
                                WHERE TABLE_NAME = '{tableName}' 
                                AND COLUMN_NAME = '{columnName}'
                            )
                            BEGIN
                                -- The column '{columnName}' exists in the table
                                UPDATE {tableName} SET {columnName} = @currentTime WHERE Id = @entityId;
                            END";

                            var parameters = new[]
                            {
                            new SqlParameter("@currentTime", currentTime),
                            new SqlParameter("@entityId", entry.OriginalValues["Id"])
                        };

                            await Database.ExecuteSqlRawAsync(checkColumnExistsSql, parameters, cancellationToken);
                        }
                    }
                }
            }

            return await base.SaveChangesAsync(cancellationToken);

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            //modelBuilder.ApplyConfiguration(new AddressConfiguration());
            ////modelBuilder.ApplyConfiguration();
            //modelBuilder.ApplyConfiguration(new CartDiscountRelationConfiguration());
            //modelBuilder.ApplyConfiguration(new CartsConfiguration());
            //modelBuilder.ApplyConfiguration(new CardTypeConfiguration());
            //modelBuilder.ApplyConfiguration(new CategoriesConfiguration());
            //modelBuilder.ApplyConfiguration(new CustomersConfiguration());
            //modelBuilder.ApplyConfiguration(new DiscountConfiguration());
            //modelBuilder.ApplyConfiguration(new OrderItemsConfiguration());
            //modelBuilder.ApplyConfiguration(new OrdersConfiguration());
            //modelBuilder.ApplyConfiguration(new PaymentCardConfiguration());
            //modelBuilder.ApplyConfiguration(new PaymentMethodConfiguration());
            //modelBuilder.ApplyConfiguration(new PaymentsConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductCartConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductCartDiscountConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductDiscountRelationConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductsConfiguration());
            //modelBuilder.ApplyConfiguration(new ProductWishlistConfiguration());
            //modelBuilder.ApplyConfiguration(new ShipmentsConfiguration());
            //modelBuilder.ApplyConfiguration(new WishlistConfiguration());

            modelBuilder.ApplyConfigurationsFromAssembly(Assembly.GetExecutingAssembly());


            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {

            base.OnConfiguring(optionsBuilder);
        }

        public override void Dispose()
        {
            base.Dispose();
        }

        public override async ValueTask DisposeAsync()
        {
            await base.DisposeAsync();
        }
    }
}
