using CMS.Application.Abstractions.Notifications;
using FluentValidation;
using MediatR;

namespace CMS.Application.CrossCuttingConcerns.Validation;

public class FluentValidationBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse>
    where TRequest : IRequest<TResponse>
{
    private readonly IEnumerable<IValidator<TRequest>> _validators;
    private readonly IUserNotification? _userNotification;

    public FluentValidationBehavior(IEnumerable<IValidator<TRequest>> validators, IUserNotification? userNotification = null)
    {
        _validators = validators;
        _userNotification = userNotification;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        if (_validators.Any())
        {
            var context = new ValidationContext<TRequest>(request);
            var failures = new List<FluentValidation.Results.ValidationFailure>();

            foreach (var validator in _validators)
            {
                var result = await validator.ValidateAsync(context, cancellationToken);
                if (!result.IsValid && result.Errors is not null)
                    failures.AddRange(result.Errors);
            }

            if (failures.Count > 0)
            {
                var messages = failures
                    .Where(f => !string.IsNullOrWhiteSpace(f.ErrorMessage))
                    .Select(f => string.IsNullOrWhiteSpace(f.PropertyName)
                        ? f.ErrorMessage
                        : $"{f.PropertyName}: {f.ErrorMessage}")
                    .ToList();

                _userNotification?.ShowValidationErrors(messages, $"Doğrulama Hatası - {typeof(TRequest).Name}");

                throw new ValidationException(failures);
            }
        }

        return await next();
    }
}


