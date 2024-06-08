using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace App.Domain.Entities.Models
{
    public class Reply
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Comment")]
        public Guid CommentId { get; set; }
        public Comments Comment { get; set; }

        [ForeignKey("Sender")]
        public Guid SenderId { get; set; }
        public UserModel Sender { get; set; }

        [MaxLength(2000)]
        public string ReplyMessage { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }

}
