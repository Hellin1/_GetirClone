using AutoMapper;
using FluentValidation;
using GetirClone.Application.Behaivours;
using GetirClone.Application.Mappings;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System.Reflection;

namespace GetirClone.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationService(this IServiceCollection services)
        {
            services.AddMediatR(Assembly.GetExecutingAssembly());
            services.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());
            services.AddTransient(typeof(IPipelineBehavior<,>), typeof(RequestValidationBehavior<,>));

            services.AddAutoMapper(opt =>
            {
                opt.AddProfiles(new List<Profile>
                {
                    new ProductProfile(),
                    new CategoryProfile(),
                    new CustomerProfile(),
                    new WishlistProfile(),
                    new PaymentCardProfile(),
                    new AddressProfile(),
                    new OrderProfile(),
                    new PaymentCardProfile(),
                    new PaymentProfile(),
                    new ShipmentProfile(),
                    new OrderItemProfile(),
                    new CartProfile(),
                    new ProductCartForProductProfile(),
                    new ProductWishlistProfile(),
                    new UserDtoProfile(),
                });
            });
        }
    }
}