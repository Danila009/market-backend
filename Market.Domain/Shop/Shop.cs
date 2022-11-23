
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Shop
{
    public class Shop
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
        [Required] public double Latitude { get; set; }
        [Required] public double Longitude { get; set; }
        [Required] public City City { get; set; }

        public virtual List<Product.Product> Products { get; set; } = new List<Product.Product>();
    }
}
