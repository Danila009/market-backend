using Market.Application.Interfaces;
using Market.Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.Product.Commands.UpdateStatusProduct
{
    public class UpdateStatusProductCommandHandler
        : IRequestHandler<UpdateStatusProductCommand>
    {

        private readonly IMarketDbContext _dbContext;

        public UpdateStatusProductCommandHandler(IMarketDbContext dbContext) =>
            _dbContext = dbContext;

        public async Task<Unit> Handle(UpdateStatusProductCommand request,
            CancellationToken cancellationToken)
        {
            var product = await _dbContext.Products.FindAsync(request.ProductId);

            if (product == null)
            {
                throw new NotFoundException(nameof(Domain.Product.Product),
                    request.ProductId);
            }

            product.Status = request.Status;

            await _dbContext.SaveChangesAsync(cancellationToken);

            return Unit.Value;
        }
    }
}
