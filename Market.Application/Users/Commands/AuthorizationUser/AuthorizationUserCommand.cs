using Market.Application.Users.Commands.CreateUser;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.Users.Commands.AuthorizationUser
{
    public class AuthorizationUserCommand : IRequest<TokenUserVm>
    {
        [Required] public string Email { get; set; }
        [Required] public string Password { get; set; }


    }
}
