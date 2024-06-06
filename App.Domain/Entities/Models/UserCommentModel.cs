using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class UserCommentModel
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string Message { get; set; }

        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        public List<ReplyModel> Replies { get; set; } = new List<ReplyModel>();

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
