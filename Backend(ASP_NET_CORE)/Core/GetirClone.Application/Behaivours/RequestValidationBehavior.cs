using FluentValidation;
using FluentValidation.Results;
using GetirClone.Application.Helpers;
using MediatR;
using System.Text;

namespace GetirClone.Application.Behaivours
{
    public class RequestValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
    {
        private readonly IEnumerable<IValidator<TRequest>> _validators;

        public RequestValidationBehavior(IEnumerable<IValidator<TRequest>> validators)
        {
            _validators = validators;
        }

        public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
        {
            if (_validators.Any())
            {
                var context = new ValidationContext<TRequest>(request);
                foreach (var validator in _validators)
                {
                    var validationResult = await validator.ValidateAsync(context);
                    if (validationResult.Errors.Any())
                    {
                        foreach (var error in validationResult.Errors)
                        {
                            error.ErrorMessage = LocalizeMessage(error);


                        }
                        throw new ValidationException(validationResult.Errors);
                    }
                }

            }

            return await next();
        }
        private string LocalizeMessage(ValidationFailure error)
        {
            return error.ErrorMessage;
        }
        private void FormatMessageString(ValidationFailure error)
        {
            foreach (var item in error.FormattedMessagePlaceholderValues)
            {
                var key = $"{{{item.Key}}}";
                error.ErrorMessage = error.ErrorMessage.Replace(key, item.Value.GetString());
            }
        }
    }
}
