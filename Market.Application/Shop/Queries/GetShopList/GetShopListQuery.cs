using MediatR;

namespace Market.Application.Shop.Queries.GetShopList
{
    public class GetShopListQuery : IRequest<ShopListVm>
    {
        public string Search { get; set; }
        public int? CityId { get; set; }
    }
}
