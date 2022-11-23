using FluentValidation;

namespace Market.Application.Shop.Queries.GetShopDetails
{
    public class GetShopDetailsQueryValidator : AbstractValidator<GetShopDetailsQuery>
    {
        public GetShopDetailsQueryValidator()
        {
            RuleFor(shop => shop.Id).NotEmpty();
        }
    }
}
