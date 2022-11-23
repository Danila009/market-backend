using MediatR;

namespace Market.Application.City.Queries.GetCityList
{
    public class GetCityListQuery : IRequest<CityListVm>
    {
        public string Search { get; set; }
    }
}
