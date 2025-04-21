using FluentValidation;

namespace Ambev.DeveloperEvaluation.WebApi.Features.Users.UpdateUser
{
    public class UpdateUserRequestValidator : AbstractValidator<UpdateUserRequest>
    {
        public UpdateUserRequestValidator()
        {
            RuleFor(x => x.Id).NotEmpty();
            RuleFor(x => x.Username).NotEmpty().Length(3, 100);
            RuleFor(x => x.Email).NotEmpty().EmailAddress();
            RuleFor(x => x.Phone).NotEmpty().Matches(@"^\(\d{2}\) \d{5}-\d{4}$").WithMessage("Phone must match the format (XX) XXXXX-XXXX");
            RuleFor(x => x.Password).MinimumLength(8)
                .Matches(@"[A-Z]").WithMessage("Password must contain at least one uppercase letter")
                .Matches(@"[a-z]").WithMessage("Password must contain at least one lowercase letter")
                .Matches(@"\d").WithMessage("Password must contain at least one number")
                .Matches(@"[\W_]").WithMessage("Password must contain at least one special character");
            RuleFor(x => x.Role).IsInEnum();
            RuleFor(x => x.Status).IsInEnum();
        }
    }
}
