using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class UserModel : IAuditable
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public string StatusOfUser { get; set; }
        public Roles Role { get; set; }
        public string PhotoPath { get; set; }
        public string Bio { get; set; }
        public List<MarkbookModel> Markbooks { get; set; }
        public List<UserCommentModel> Comments { get; set; }










        //----------------------------------------------------------------------
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;
        public DateTimeOffset UpdatedDate { get; set; }
        public DateTimeOffset DeletedDate { get; set; }
        public bool IsDeleted { get; set; } = false;
    }
}
