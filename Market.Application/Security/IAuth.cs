using Market.Domain.User;
using System.Security.Claims;

namespace Market.Application.Security
{
    public interface IAuth
    {

        string GetRefreshToken();

        string CreateToken(string email, string userId,
            UserRole userRole);

        Claim[] Claims(string email, string userId,
            UserRole userRole);
    }
}
