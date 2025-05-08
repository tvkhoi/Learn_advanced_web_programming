using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class UserDomainModel
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string? Username { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? Role { get; set; } = "User";
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public ICollection<TopicDomainModel>? Topics { get; set; }
        public ICollection<MessageDomainModel>? Messages { get; set; }
    }
}
