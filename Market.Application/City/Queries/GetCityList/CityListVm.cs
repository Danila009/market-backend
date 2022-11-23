using System.Collections.Generic;

namespace Market.Application.City.Queries.GetCityList
{
    public class CityListVm
    {
        public int Count
        {
            get
            {
                return Cities.Count;
            }
        }

        public IList<CityLookupDto> Cities { get; set; }
    }
}
