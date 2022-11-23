using System;

namespace Market.Application.Common.Exceptions
{
    public class UserExistsException : Exception
    {
        public UserExistsException(string email)
            : base($"A user with this email {email} already exists") { }
    }
}
