using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain
{
    public class Country
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        public virtual List<City> Cities { get; set; } = new List<City>();
    }
}
