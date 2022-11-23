using System.Collections.Generic;

namespace Market.Application.Product.Filters.Category.Queries.GetCategoryList
{
    public class CategoryListVm
    {
        public int Count
        {
            get
            {
                return Categories.Count;
            }
        }
        public IList<CategoryLookupDto> Categories { get; set; }
    }
}
