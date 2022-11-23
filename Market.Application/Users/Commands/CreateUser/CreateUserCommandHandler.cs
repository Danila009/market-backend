using System;
using System.Threading;
using System.Threading.Tasks;
using Market.Application.Interfaces;
using MediatR;
using Market.Domain.User;
using Market.Application.Security;
using Microsoft.EntityFrameworkCore;
using Market.Application.Common.Exceptions;
using Market.Application.Common;

namespace Market.Application.Users.Commands.CreateUser
{
    public class CreateUserCommandHandler
        : IRequestHandler<CreateUserCommand, TokenUserVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IAuth _auth;

        public CreateUserCommandHandler(IMarketDbContext dbContext, IAuth auth) =>
            (_dbContext, _auth) = (dbContext, auth);

        public async Task<TokenUserVm> Handle(CreateUserCommand request,
            CancellationToken cancellationToken)
        {
            var userExists = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email) != null;

            if (userExists)
            {
                throw new UserExistsException(request.Email);
            }

            var userId = Guid.NewGuid();

            string refreshToken = _auth.GetRefreshToken();

            var newUser = new User
            {
                Id = userId,
                Username = request.Username,
                Email = request.Email,
                Password = PasswordHash.CreateHash(request.Password),
                RefreshToken = refreshToken
            };

            await _dbContext.Users.AddAsync(newUser, cancellationToken);
            await _dbContext.SaveChangesAsync(cancellationToken);

            var jwtToken = _auth.CreateToken(email: request.Email,
                userId: userId.ToString(), userRole: UserRole.BASE_USER);

            return new TokenUserVm
            {
                UserId = userId,
                AccessToken = jwtToken,
                UserRole = UserRole.BASE_USER,
                RefreshToken = refreshToken
            };
        }
    }
}
