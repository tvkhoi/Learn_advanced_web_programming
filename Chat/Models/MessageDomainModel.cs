using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace Chat.Models
{
    public class MessageDomainModel
    {
        [Key]
        public int Id { get; set; }
        public string? Content { get; set; }
        public int? SenderId { get; set; }
        public int? TopicId { get; set; }
        public DateTime? CreatedAt { get; set; }
        [ForeignKey("SenderId")]
        public UserDomainModel? Sender { get; set; }
        [ForeignKey("TopicId")]
        public TopicDomainModel? Topic { get; set; }
    }
}
