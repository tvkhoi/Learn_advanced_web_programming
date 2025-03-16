using System.ComponentModel.DataAnnotations;

namespace Example2.Models
{
    public class Message
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string Content { get; set; }

        public int SenderId { get; set; }

        public int TopicId { get; set; }

        public DateTime CreatedAt { get; set; }

        // Navigation properties
        public virtual User User { get; set; }
        public virtual Topic Topic { get; set; }
    }
}
