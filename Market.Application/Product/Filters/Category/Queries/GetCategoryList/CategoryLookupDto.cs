using AutoMapper;
using Market.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.Product.Filters.Category.Queries.GetCategoryList
{
    public class CategoryLookupDto : IMapWith<Domain.Product.Filters.Category>
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Product.Filters.Category, CategoryLookupDto>();
        }
    }
}
