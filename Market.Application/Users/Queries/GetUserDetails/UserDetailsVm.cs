using AutoMapper;
using Market.Application.Common.Mappings;
using Market.Domain.User;
using System;

namespace Market.Application.Users.Queries.GetUserDetails
{
    public class UserDetailsVm : IMapWith<User>
    {
        public Guid Id { get; set; }
        public string Username { get; set; }
        public string Email { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<User, UserDetailsVm>();
        }
    }
}
