using Market.Application.City.Queries.GetCityList;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Market.WebApi.Controllers
{
    public class CityController : BaseController
    {

        [HttpGet]
        public async Task<ActionResult<CityListVm>> GetAll(string search)
        {
            var query = new GetCityListQuery { Search = search };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
