using MediatR;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.Users.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommand : IRequest
    {
        [Required] public string RefreshToken { get; set; }
    }
}
