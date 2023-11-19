using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace AssetTracking.Models
{
    public class Product
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Id { get; set; }
        [Required]
        [StringLength(50)]
        public string Brand { get; set; }
        [Required]
        [StringLength(50)]
        public string Name { get; set; }
        [Required]
        public int Price { get; set; }
        [Required]
        public DateTime PurchaseDate { get; set; }
        [ForeignKey("OfficeId")]
        public int OfficeId { get; set; }
        public Office? Office { get; set; }
    }
}
