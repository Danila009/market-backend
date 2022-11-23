using System;
using FluentValidation;

namespace Market.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryValidator : AbstractValidator<GetUserDetailsQuery>
    {
        public GetUserDetailsQueryValidator()
        {
            RuleFor(user => user.Id).NotEqual(Guid.Empty);
        }
    }
}
