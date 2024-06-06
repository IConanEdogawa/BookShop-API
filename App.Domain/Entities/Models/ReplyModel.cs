using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class ReplyModel
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Sender")]
        public Guid SenderId { get; set; }
        public UserModel Sender { get; set; }

        [ForeignKey("UserComment")]
        public Guid UserCommentId { get; set; }
        public UserCommentModel UserComment { get; set; }

        [MaxLength(2000)]
        public string ReplyMessage { get; set; }
    }
}
