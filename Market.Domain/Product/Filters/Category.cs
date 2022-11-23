

using System.ComponentModel.DataAnnotations;

namespace Market.Domain.Product.Filters
{
    public class Category
    {
        [Key] public int Id { get; set; }
        [Required] public string Name { get; set; }
    }
}
