using AutoMapper;
using Market.Application.Interfaces;
using Market.Application.Common.Exceptions;
using MediatR;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Market.Application.Shop.Queries.GetShopDetails
{
    public class GetShopDetailsQueryHandler
        : IRequestHandler<GetShopDetailsQuery, ShopDetailsVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetShopDetailsQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ShopDetailsVm> Handle(GetShopDetailsQuery request,
            CancellationToken cancellationToken)
        {
            var shop = await _dbContext.Shops
                .Include(u => u.City)
                .FirstOrDefaultAsync(u => u.Id == request.Id, cancellationToken);

            if (shop == null)
            {
                throw new NotFoundException(nameof(Domain.Shop.Shop), request.Id);
            }

            return _mapper.Map<ShopDetailsVm>(shop);
        }
    }
}
