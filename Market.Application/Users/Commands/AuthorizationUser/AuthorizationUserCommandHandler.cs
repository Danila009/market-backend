using AutoMapper;
using Market.Application.Common;
using Market.Application.Common.Exceptions;
using Market.Application.Interfaces;
using Market.Application.Security;
using Market.Application.Users.Commands.CreateUser;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.Users.Commands.AuthorizationUser
{
    internal class AuthorizationUserCommandHandler
        : IRequestHandler<AuthorizationUserCommand, TokenUserVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;
        private readonly IAuth _auth;

        public AuthorizationUserCommandHandler(IMarketDbContext dbContext,
            IMapper mapper, IAuth auth) => (_dbContext, _mapper, _auth) = (dbContext, mapper, auth);

        public async Task<TokenUserVm> Handle(AuthorizationUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users
                .FirstOrDefaultAsync(u => u.Email == request.Email);

            if(user == null)
            {
                throw new NotFoundException(nameof(Domain.User.User), request.Email);
            }

            if(!PasswordHash.ValidatePassword(request.Password, user.Password))
            {
                throw new Exception("Invalid password");
            }

            var jwtToken = _auth.CreateToken(userId: user.Id.ToString(),
                email: user.Email, userRole: user.Role);

            string refreshToken = _auth.GetRefreshToken();

            user.RefreshToken = refreshToken;
            await _dbContext.SaveChangesAsync(cancellationToken);

            return new TokenUserVm
            {
                AccessToken = jwtToken,
                UserId = user.Id,
                UserRole = user.Role,
                RefreshToken = refreshToken
            };
        }
    }
}
