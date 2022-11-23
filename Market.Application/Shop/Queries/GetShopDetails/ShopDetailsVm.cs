using Market.Application.Common.Mappings;
using Market.Domain;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.Shop.Queries.GetShopDetails
{
    public class ShopDetailsVm : IMapWith<Domain.Shop.Shop>
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public double Latitude { get; set; }
        [Required] public double Longitude { get; set; }
        [Required] public Domain.City City { get; set; }
    }
}
