using Market.Application.Shop.Queries.GetShopDetails;
using Market.Application.Shop.Queries.GetShopList;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace Market.WebApi.Controllers
{
    public class ShopController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ShopListVm>> GetAll(string search, int? cityId)
        {
            var query = new GetShopListQuery { Search = search, CityId = cityId };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ShopDetailsVm>> GetById(int id)
        {
            var query = new GetShopDetailsQuery { Id = id };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }
    }
}
