using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class BookComment
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string CommentText { get; set; }

        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public UserModel User { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
