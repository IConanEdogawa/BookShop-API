using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace App.Domain.Entities.Models
{
    public class Reply
    {
        [Key]
        public Guid Id { get; set; }

        // Ссылка на исходный комментарий
        public Guid OriginalCommentId { get; set; }
        [JsonIgnore]
        public Comments OriginalComment { get; set; }

        // Ссылка на комментарий-ответ
        public Guid ReplyCommentId { get; set; }
        [JsonIgnore]
        public Comments ReplyComment { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
