using Market.Domain.User;
using System;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.Users.Commands.CreateUser
{
    public class TokenUserVm
    {
        [Required] public string AccessToken { get; set; }
        [Required] public string RefreshToken { get; set; }

        [Required] public Guid UserId { get; set; }
        [Required] public UserRole UserRole { get; set; }
    }
}
