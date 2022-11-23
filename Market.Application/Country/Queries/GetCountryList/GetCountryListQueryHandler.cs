using AutoMapper;
using AutoMapper.QueryableExtensions;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.Country.Queries.GetCountryList
{
    public class GetCountryListQueryHandler
        :IRequestHandler<GetCountryListQuery, CountryListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCountryListQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CountryListVm> Handle(GetCountryListQuery request,
            CancellationToken cancellationToken)
        {
            var countries = await _dbContext.Countries
                .ProjectTo<CountryLookupDto>(_mapper.ConfigurationProvider)
                .ToListAsync(cancellationToken);

            return new CountryListVm { Countries = countries };
        }
    }
}
