using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Market.Application.Interfaces;
using Market.Application.Common.Exceptions;
using MediatR;
using Market.Domain.User;

namespace Market.Application.Users.Queries.GetUserDetails
{
    public class GetUserDetailsQueryHandler
        : IRequestHandler<GetUserDetailsQuery, UserDetailsVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetUserDetailsQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<UserDetailsVm> Handle(GetUserDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(new object[] { request.Id },
                cancellationToken);
        
            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            return _mapper.Map<UserDetailsVm>(user);
        }
    }
}
