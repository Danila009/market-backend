using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.City.Queries.GetCityList
{
    public class GetCityListQueryHandler
        : IRequestHandler<GetCityListQuery, CityListVm>
    {
        public readonly IMarketDbContext _dbContext;
        public readonly IMapper _mapper;

        public GetCityListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CityListVm> Handle(GetCityListQuery request,
            CancellationToken cancellationToken)
        {
            IQueryable<Domain.City> query = _dbContext.Cities;

            if (!string.IsNullOrEmpty(request.Search))
            {
                query = query.Where(
                    u => u.Name.ToLower().Contains(request.Search.ToLower()));
            }

            var cities = await query
                .ProjectTo<CityLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CityListVm { Cities = cities };
        }
    }
}
