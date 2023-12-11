using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class CreateCategoryCommandValidator : AbstractValidator<CreateCategoryCommand>
    {
        public CreateCategoryCommandValidator()
        {
            RuleFor(cmd => cmd.Name).NotEmpty().MaximumLength(100);
            RuleFor(cmd => cmd.Description).MaximumLength(100);
        }
    }
}
