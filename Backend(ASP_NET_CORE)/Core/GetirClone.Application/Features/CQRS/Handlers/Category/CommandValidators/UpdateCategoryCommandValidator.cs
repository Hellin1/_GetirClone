using FluentValidation;
using GetirClone.Application.Features.CQRS.Commands;
using GetirClone.Application.Interfaces;
using GetirClone.Domain.Entities;

namespace GetirClone.Application.Features.CQRS.Handlers
{
    public class UpdateCategoryCommandValidator : AbstractValidator<UpdateCategoryCommand>
    {
        private readonly IUow _uow;
        public UpdateCategoryCommandValidator(IUow uow)
        {
            _uow = uow;

            RuleFor(cmd => cmd.Id).Cascade(CascadeMode.Stop).NotEmpty().MustAsync(BeOnDataBase);
            RuleFor(cmd => cmd.Name).NotEmpty();
            RuleFor(cmd => cmd.Description).NotEmpty().MaximumLength(400);
        }
        private async Task<bool> BeOnDataBase(int id, CancellationToken token)
        {
            var category = await _uow.GetRepository<Category>().GetByIdAsync(id, token);
            if (category == null) return false;

            return true;
        }
    }
}
