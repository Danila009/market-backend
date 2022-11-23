using MediatR;

namespace Market.Application.Users.Commands.CreateUser
{
    public class CreateUserCommand : IRequest<TokenUserVm>
    {
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
