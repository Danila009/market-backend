using AutoMapper;
using Market.Application.Interfaces;
using Market.Application.Security;
using Market.Application.Common.Exceptions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;
using Market.Domain.User;

namespace Market.Application.Users.Commands.RefreshToken
{
    internal class RefreshTokenCommandHandler
        : IRequestHandler<RefreshTokenCommand, string>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IAuth _auth;

        public RefreshTokenCommandHandler(IMarketDbContext dbContext,
            IAuth auth) => (_dbContext, _auth) = (dbContext, auth);

        public async Task<string> Handle(RefreshTokenCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FirstOrDefaultAsync(
                u => u.RefreshToken == request.RefreshToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.RefreshToken);
            }

            var jwtToken = _auth.CreateToken(email: user.Email,
                userId: user.Id.ToString(), userRole: user.Role);

            return jwtToken;
        }
    }
}
