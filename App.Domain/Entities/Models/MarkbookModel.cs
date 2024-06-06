using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class MarkbookModel
    {
        [Key]
        public Guid Id { get; set; }

        [ForeignKey("Book")]
        public Guid BookId { get; set; }
        public Book Book { get; set; }

        [MaxLength(100)]
        public string Page { get; set; }

        [ForeignKey("User")]
        public Guid UserId { get; set; }
        public UserModel User { get; set; }
    }
}
