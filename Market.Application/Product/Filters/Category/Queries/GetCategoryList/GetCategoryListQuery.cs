using MediatR;

namespace Market.Application.Product.Filters.Category.Queries.GetCategoryList
{
    public class GetCategoryListQuery : IRequest<CategoryListVm>
    {
        public string Search { get; set; }
    }
}
