using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class UserModel : IAuditable
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string FullName { get; set; }

        [Required]
        [EmailAddress]
        public string Email { get; set; }

        [Required]
        public string Password { get; set; }

        [MaxLength(50)]
        public string StatusOfUser { get; set; }

        [ForeignKey("RoleId")]
        public Roles Role { get; set; }
        public Guid RoleId { get; set; }

        public string PhotoPath { get; set; }

        [MaxLength(1000)]
        public string Bio { get; set; }

        public List<MarkbookModel> Markbooks { get; set; } = new List<MarkbookModel>();
        public List<UserCommentModel> Comments { get; set; } = new List<UserCommentModel>();

        //----------------------------------------------------------------------
        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTimeOffset UpdatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? DeletedDate { get; set; }

        public bool IsDeleted { get; set; } = false;
    }
}
