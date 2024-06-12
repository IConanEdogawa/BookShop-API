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
    public class Comments
    {
        public Guid Id { get; set; }

        [Required]
        [MaxLength(2000)]
        public string CommentText { get; set; }

        public Guid BookId { get; set; }
        [JsonIgnore]
        public Book Book { get; set; }

        public Guid UserId { get; set; }
        [JsonIgnore]
        public UserModel User { get; set; }



        [DataType(DataType.DateTime)]
        public DateTime CreatedDate { get; set; } = DateTime.UtcNow;
    }
}
