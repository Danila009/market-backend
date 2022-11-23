using MediatR;

namespace Market.Application.Shop.Queries.GetShopDetails
{
    public class GetShopDetailsQuery : IRequest<ShopDetailsVm>
    {
        public int Id { get; set; }
    }
}
