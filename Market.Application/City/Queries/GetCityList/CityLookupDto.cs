using AutoMapper;
using Market.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.City.Queries.GetCityList
{
    public class CityLookupDto : IMapWith<Domain.City>
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(128)] public string Name { get; set; }
        [Required] public double Latitude { get; set; }
        [Required] public double Longitude { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.City, CityLookupDto>();
        }
    }
}
