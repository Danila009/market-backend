using System.Collections.Generic;

namespace Market.Application.Shop.Queries.GetShopList
{
    public class ShopListVm
    {
        public int Count
        {
            get
            {
                return Shops.Count;
            }
        }

        public IList<ShopLookupDto> Shops { get; set; }
    }
}
