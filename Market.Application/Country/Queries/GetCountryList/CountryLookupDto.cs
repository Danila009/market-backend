using AutoMapper;
using Market.Application.Common.Mappings;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.Country.Queries.GetCountryList
{
    public class CountryLookupDto : IMapWith<Domain.Country>
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Country, CountryLookupDto>();
        }
    }
}
