using System.Collections.Generic;

namespace Market.Application.Product.Queries.GetProductList
{
    public class ProductListVm
    {
        public int Count
        {
            get
            {
                return Products.Count;
            }
        }
        public IList<ProductLookupDto> Products { get; set; }
    }
}
