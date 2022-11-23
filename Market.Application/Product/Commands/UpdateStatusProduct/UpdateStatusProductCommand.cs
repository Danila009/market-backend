using Market.Domain.Product;
using MediatR;

namespace Market.Application.Product.Commands.UpdateStatusProduct
{
    public class UpdateStatusProductCommand : IRequest
    {
        public int ProductId { get; set; }
        public ProductStatus Status { get; set; }
    }
}
