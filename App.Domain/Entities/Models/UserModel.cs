using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.Json.Serialization;

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


        public int RoleId { get; set; }
        [JsonIgnore]
        public Roles Role { get; set; }

        public string? PhotoUrl  { get; set; }

        [MaxLength(1000)]
        public string? Bio { get; set; }

        public List<Comments>? Comments { get; set; } = new List<Comments>();

        //----------------------------------------------------------------------
        [DataType(DataType.DateTime)]
        public DateTimeOffset CreatedDate { get; set; } = DateTimeOffset.UtcNow;

        [DataType(DataType.DateTime)]
        public DateTimeOffset? UpdatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTimeOffset? DeletedDate { get; set; }

        public bool IsDeleted { get; set; } = false;



        public int? BooksRead { get; set; } = 0;
        public int? CommentsMade { get; set; } = 0;
        public int? LikesGiven { get; set; } = 0;
    }
}
