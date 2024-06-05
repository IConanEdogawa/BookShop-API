using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class UserCommentModel
    {
        public Guid Id { get; set; }
        public string Message { get; set; }
        public string TitleId { get; set; }
        public List<ReplyModel> Replied { get; set; } 
    }
}
