using Market.Application.Product.Commands.CreateProduct;
using Market.Application.Product.Commands.SaveImageProduct;
using Market.Application.Product.Commands.UpdateStatusProduct;
using Market.Application.Product.Filters.Category.Queries.GetCategoryList;
using Market.Application.Product.Queries.GetProductList;
using Market.Domain.Product;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Market.WebApi.Controllers
{
    public class ProductController : BaseController
    {
        [HttpGet]
        public async Task<ActionResult<ProductListVm>> GetAll(string search,
            ProductStatus? status,
            [FromQuery]List<int> categoriesId, [FromQuery]List<int> shopsId)
        {
            var query = new GetProductListQuery 
            {
                Seacrh = search,
                CategoriesId = categoriesId,
                ShopsId = shopsId,
                Status = status
            };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [HttpGet("Categories")]
        public async Task<ActionResult<CategoryListVm>> GetAll(string search)
        {
            var query = new GetCategoryListQuery { Search = search };

            var vm = await Mediator.Send(query);

            return Ok(vm);
        }

        [Authorize(Roles = "ADMIN_USER")]
        [HttpPost]
        public async Task<ActionResult<CreateProductVm>> CreateProduct(
            [FromBody] CreateProductCommand command)
        {
            var vm = await Mediator.Send(command);

            return Ok(vm);
        }

        [Authorize(Roles = "ADMIN_USER")]
        [HttpPatch("{id}/Status")]
        public async Task<ActionResult> UpdateStatus(int id, ProductStatus status)
        {
            var command = new UpdateStatusProductCommand
            {
                ProductId = id,
                Status = status
            };

            await Mediator.Send(command);

            return Ok("Successfully");
        }

        //[Produces("image/png")]
        [Authorize(Roles = "ADMIN_USER")]
        [HttpPost("{id}/Image")]
        public async Task<ActionResult> AddImage(int id, IFormFile image)
        {
            var command = new SaveImageProductCommand
            {
                ProductId = id,
                Image = image
            };

            var vm = Mediator.Send(command);

            return Ok(vm);
        }

        [HttpGet("{id}_image.jpg")]
        public async Task<ActionResult> GetImage(int id)
        {


            return Ok("Successfully");
        }
    }
}
