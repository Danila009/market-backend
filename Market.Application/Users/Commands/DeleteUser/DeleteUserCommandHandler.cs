using System.Threading;
using System.Threading.Tasks;
using Market.Application.Interfaces;
using Market.Application.Common.Exceptions;
using MediatR;
using Market.Domain.User;

namespace Market.Application.Users.Commands.DeleteUser
{
    public class DeleteUserCommandHandler
        : IRequestHandler<DeleteUserCommand>
    {
        private readonly IMarketDbContext _dbContext;

        public DeleteUserCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(DeleteUserCommand request,
            CancellationToken cancellationToken)
        {
            var user = await _dbContext.Users.FindAsync(new object[] { request.Id },
                cancellationToken);

            if (user == null)
            {
                throw new NotFoundException(nameof(User), request.Id);
            }

            _dbContext.Users.Remove(user);
            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
