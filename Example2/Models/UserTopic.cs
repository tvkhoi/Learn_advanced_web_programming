using System.ComponentModel.DataAnnotations;

namespace Example2.Models
{
    public class UserTopic
    {
        [Required]
        public int UserId { get; set; }

        [Required]
        public int TopicId { get; set; }

        [StringLength(20)]
        public string Role { get; set; }

        public DateTime JoinedAt { get; set; }

        // Composite key setup
        public virtual User User { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
