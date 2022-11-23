using FluentValidation;

namespace Market.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandValidator : AbstractValidator<CreateUserCommand>
    {
        public CreateUserCommandValidator()
        {
            RuleFor(createUserCommand =>
                createUserCommand.Username).NotEmpty().MaximumLength(128);

            RuleFor(createUserCommand => 
                createUserCommand.Email).NotEmpty().MaximumLength(64);

            RuleFor(createUserCommand =>
                createUserCommand.Password).NotEmpty().MaximumLength(64);

        }
    }
}
