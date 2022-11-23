using System;

namespace Market.Domain.User
{
    public class User
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public string RefreshToken { get; set; }

        public virtual UserRole Role => UserRole.BASE_USER;
    }
}
