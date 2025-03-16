using System.ComponentModel.DataAnnotations;

namespace Example2.Models
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(50)]
        public string Username { get; set; }

        [Required]
        [StringLength(255)]
        public string PasswordHash { get; set; }

        [StringLength(100)]
        public string Email { get; set; }

        [StringLength(100)]
        public string FullName { get; set; }

        [StringLength(20)]
        public string Role { get; set; } = "User";

        public bool IsGuest { get; set; } = false;

        public DateTime CreatedAt { get; set; }

        public DateTime? UpdatedAt { get; set; }
    }
}

