using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using MediatR;

namespace Market.Application.Product.Commands.CreateProduct
{
    public class CreateProductCommand : IRequest<CreateProductVm>
    {
        [Required, MaxLength(128)] public string Title { get; set; }
        [Required, MaxLength(504)] public string Description { get; set; }
        [Required] public int Price { get; set; }
        [Required] public int CategoryId { get; set; }
        [Required] public List<int> ShopsId { get; set; } = new List<int>();
    }
}
