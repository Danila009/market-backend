using System.Collections.Generic;

namespace Market.Application.Country.Queries.GetCountryList
{
    public class CountryListVm
    {
        public int Count
        {
            get
            {
                return Countries.Count;
            }
        }
        public IList<CountryLookupDto> Countries { get; set; }
    }
}
