using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class ReplyModel
    {
        [Key]
        public int Id { get; set; }
        public Guid SenderId { get; set; }
        public Guid RepliedId { get; set; }
    }
}
