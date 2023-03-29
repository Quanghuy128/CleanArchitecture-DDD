using FluentValidation;

namespace BuberDinner.Application.Authentication.Commands.Register
{
    public class RequestCommandValidator : AbstractValidator<RegisterCommand>
    {
        public RequestCommandValidator() {
            RuleFor(x => x.FirstName).NotEmpty();
            RuleFor(x => x.LastName).NotEmpty();
            RuleFor(x => x.Email).NotEmpty();
            RuleFor(x => x.Password).NotEmpty();
        }
    }
}
