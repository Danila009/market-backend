using Market.Domain.Product;
using MediatR;
using System.Collections.Generic;

namespace Market.Application.Product.Queries.GetProductList
{
    public class GetProductListQuery : IRequest<ProductListVm>
    {
        public ProductStatus? Status { get; set; }
        public string Seacrh { get; set; }
        public virtual List<int> CategoriesId { get; set; } = new List<int>();
        public virtual List<int> ShopsId { get; set; } = new List<int>();
    }
}
