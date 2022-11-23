using AutoMapper;
using Market.Application.Common.Exceptions;
using Market.Application.City.Queries.GetCityList;
using Market.Application.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Market.Application.City.Queries.GetCityListByCountry
{
    internal class GetCityListFromCountryQueryHandler
        : IRequestHandler<GetCityListFromCountryQuery, CityListVm>
    {
        private readonly IMarketDbContext _dbContext;
        private readonly IMapper _mapper;

        public GetCityListFromCountryQueryHandler(IMarketDbContext dbContext,
            IMapper mapper) => (_dbContext, _mapper) = (dbContext, mapper);

        public async Task<CityListVm> Handle(GetCityListFromCountryQuery request,
            CancellationToken cancellationToken)
        {
            var query = await _dbContext.Countries
                .Include(u => u.Cities)
                .FirstOrDefaultAsync(u => u.Id == request.CountryId);

            if (query == null)
            {
                throw new NotFoundException(nameof(Domain.Country), request.CountryId);
            }

            var cities = _mapper.Map<List<CityLookupDto>>(query.Cities);

            return new CityListVm { Cities = cities };
        }
    }
}
