using Market.Application.City.Queries.GetCityList;
using MediatR;

namespace Market.Application.City.Queries.GetCityListByCountry
{
    public class GetCityListFromCountryQuery : IRequest<CityListVm>
    {
        public int CountryId { get; set; }
    }
}
