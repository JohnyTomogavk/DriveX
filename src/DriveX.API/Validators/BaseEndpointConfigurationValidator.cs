using DriveX.API.Endpoints.Base;
using FluentValidation;

namespace DriveX.API.Validators;

public class BaseEndpointConfigurationValidator : AbstractValidator<ApiEndpointBase>
{
    public BaseEndpointConfigurationValidator()
    {
        RuleFor(x => x.RequestPath).NotEmpty().WithMessage($"{nameof(ApiEndpointBase.RequestPath)} cannot be empty");
        RuleFor(x => x.MapMethod).NotEmpty().WithMessage($"{nameof(ApiEndpointBase.MapMethod)} must be a valid http method");
        RuleFor(x => x.RequestHandler).NotNull().WithMessage($"{nameof(ApiEndpointBase.RequestHandler)} must be defined");
    }
}
