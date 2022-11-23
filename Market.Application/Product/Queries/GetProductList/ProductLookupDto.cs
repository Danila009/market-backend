using AutoMapper;
using Market.Application.Common.Mappings;
using Market.Domain.Product;
using Market.Domain.Product.Filters;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace Market.Application.Product.Queries.GetProductList
{
    public class ProductLookupDto : IMapWith<Domain.Product.Product>
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(128)] public string Title { get; set; }
        [Required, MaxLength(504)] public string Description { get; set; }
        [Required] public int Price { get; set; }
        [Required] public Category Category { get; set; }
        [Required] public ProductStatus Status { get; set; }
        [Required] public DateTime DateCreation { get; set; }

        public virtual List<Domain.Image> Images { get; set; } = new List<Domain.Image>();

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Domain.Product.Product, ProductLookupDto>();
        }
    }
}
