using System.ComponentModel.DataAnnotations;

namespace Market.Domain
{
    public class City
    {
        [Key] public int Id { get; set; }
        [Required, MaxLength(128)] public string Name { get; set; }
        [Required] public double Latitude { get; set; }
        [Required] public double Longitude { get; set; }
    }
}
