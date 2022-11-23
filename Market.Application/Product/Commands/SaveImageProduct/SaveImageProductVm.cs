using System.ComponentModel.DataAnnotations;

namespace Market.Application.Product.Commands.SaveImageProduct
{
    public class SaveImageProductVm
    {
        [Required] public string Url { get; set; }
    }
}
