using System;
using AutoMapper;
using Market.Application.Common.Mappings;
using Market.Domain.User;

namespace Market.Application.Users.Queries.GetUserList
{
    public class UserLookupDto : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserLookupDto>();
        }
    }
}
