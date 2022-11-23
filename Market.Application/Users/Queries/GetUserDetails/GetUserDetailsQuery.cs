using MediatR;
using System;

namespace Market.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQuery : IRequest<UserDetailsVm>
    {
        public Guid Id { get; set; }
    }
}
