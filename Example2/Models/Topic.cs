using System.ComponentModel.DataAnnotations;

namespace Example2.Models
{
    public class Topic
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(100)]
        public string Title { get; set; }

        [StringLength(255)]
        public string Description { get; set; }

        public int CreatedBy { get; set; }

        public bool IsPublic { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }

        // Navigation property
        public virtual User User { get; set; }
    }
}
