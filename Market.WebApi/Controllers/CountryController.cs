using Market.Application.City.Queries.GetCityList;
using Market.Application.City.Queries.GetCityListByCountry;
using Market.Application.Country.Queries.GetCountryList;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Market.WebApi.Controllers
{
    public class CountryController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<CountryListVm>> GetAll()
        {
            var query = new GetCountryListQuery();

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}/Cities")]
        public async Task<ActionResult<CityListVm>> GetCityByCountry(int id)
        {
            var query = new GetCityListFromCountryQuery { CountryId = id };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
