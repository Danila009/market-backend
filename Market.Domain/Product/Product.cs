using Market.Domain.Product.Filters;
using Market.Domain.Shop;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Product
{
    public class Product
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(128)] public string Title { get; set; }
        [Required, MaxLength(504)] public string Description { get; set; }
        [Required] public int Price { get; set; }
        [Required] public Category Category { get; set; }
        [Required] public ProductStatus Status { get; set; }
        [Required] public DateTime DateCreation { get; set; }

        public virtual List<Image> Images { get; set; } = new List<Image>();
        public virtual List<Shop.Shop> Shops { get; set; } = new List<Shop.Shop>();
    }
}
