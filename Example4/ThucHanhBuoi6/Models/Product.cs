using System.ComponentModel.DataAnnotations;

namespace ThucHanhBuoi6.Models
{
    public class Product
    {
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Name { get; set; }

        [Range(0, double.MaxValue)]
        public double Price { get; set; }
    }

}
