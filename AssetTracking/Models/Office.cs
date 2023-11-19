using System.ComponentModel.DataAnnotations;

namespace AssetTracking.Models
{
    public class Office
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public string Location { get; set; }
        [Required]
        public string Currency { get; set; }
        public ICollection<Product> Products { get; set; } = new List<Product>();
    }
}
