using Evice.Authentication.Application.Commands.Requests;
using FluentValidation;

namespace Evice.Authentication.Application.Validators.User
{
    public class AddUserRequestValidator : AbstractValidator<AddUserRequest>
    {
        public AddUserRequestValidator()
        {
            RuleFor(r => r.Email)
                .NotNull()
                .NotEmpty()
                .MaximumLength(250);

            RuleFor(r => r.Name)
                .NotNull()
                .NotEmpty()
                .MinimumLength(2);

            RuleFor(r => r.Password)
                .NotNull()
                .NotEmpty()
                .Equal(r => r.ConfirmPassword)
                .MinimumLength(8)
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");

            RuleFor(r => r.ConfirmPassword)
                .NotNull()
                .NotEmpty()
                .Equal(r => r.Password)
                .MinimumLength(8)
                .Matches(@"[A-Z]+").WithMessage("Your password must contain at least one uppercase letter.")
                .Matches(@"[a-z]+").WithMessage("Your password must contain at least one lowercase letter.")
                .Matches(@"[0-9]+").WithMessage("Your password must contain at least one number.");
        }
    }
}