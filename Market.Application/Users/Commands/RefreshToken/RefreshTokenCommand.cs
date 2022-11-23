using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.Users.Commands.RefreshToken
{
    public class RefreshTokenCommand : IRequest<string>
    {
        [Required] public string RefreshToken { get; set; }
    }
}
