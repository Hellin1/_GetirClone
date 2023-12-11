using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateAddressCommandValidator : AbstractValidator<CreateAddressCommand>
    {
        public CreateAddressCommandValidator()
        {
            RuleFor(cmd => cmd.CustomerId).NotEmpty();
            RuleFor(cmd => cmd.Title).NotEmpty().MaximumLength(100);
            RuleFor(cmd => cmd.AddressString).NotEmpty().MaximumLength(700);
            RuleFor(cmd => cmd.BuildingNumber).NotEmpty().MaximumLength(20);
            RuleFor(cmd => cmd.Floor).NotEmpty().MaximumLength(20);
            RuleFor(cmd => cmd.ApartmentNumber).NotEmpty().MaximumLength(20);
            RuleFor(cmd => cmd.AddressTypeId).GreaterThanOrEqualTo(0);
            RuleFor(cmd => cmd.AddressImageId).GreaterThanOrEqualTo(0);

        }
    }
}
