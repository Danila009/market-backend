using MediatR;
using Microsoft.AspNetCore.Http;

namespace Market.Application.Product.Commands.SaveImageProduct
{
    public class SaveImageProductCommand : IRequest<SaveImageProductVm>
    {
        public int ProductId { get; set; }
        public IFormFile Image { get; set; }
    }
}
