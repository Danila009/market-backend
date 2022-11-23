using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.Shop.Queries.GetShopList
{
    public class GetShopListQueryHandler
        : IRequestHandler<GetShopListQuery, ShopListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetShopListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<ShopListVm> Handle(GetShopListQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Domain.Shop.Shop> query = _dbContext.Shops
                .Include(u => u.City);

            if(request.CityId != null)
            {
                query = query.Where(u => u.City.Id == request.CityId);
            }

            if(!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(u => u.Name.ToLower().Contains(request.Search.ToLower()));
            }

            var shop = await query
                .ProjectTo<ShopLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new ShopListVm { Shops = shop };
        }
    }
}
