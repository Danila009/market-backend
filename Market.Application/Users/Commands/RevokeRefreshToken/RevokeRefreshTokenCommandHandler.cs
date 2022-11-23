using Microsoft.EntityFrameworkCore;
using Market.Application.Interfaces;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Market.Application.Common.Exceptions;
using Market.Domain.User;

namespace Market.Application.Users.Commands.RevokeRefreshToken
{
    public class RevokeRefreshTokenCommandHandler
        : IRequestHandler<RevokeRefreshTokenCommand>
    {
        public readonly IMarketDbContext _dbContext;

        public RevokeRefreshTokenCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(RevokeRefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.RefreshToken == request.RefreshToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.RefreshToken);
            }

            user.RefreshToken = null;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
