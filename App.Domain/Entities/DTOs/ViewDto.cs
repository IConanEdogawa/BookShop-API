using App.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.DTOs
{
    public class ViewDto
    {
        public Guid Id { get; set; }
        public string FullName { get; set; }
        public string Email { get; set; }
        public string StatusOfUser { get; set; }
        public string PhotoPath { get; set; }
        public Guid RoleId { get; set; }
        public string Bio { get; set; }
        public List<MarkbookModel>? Markbooks { get; set; } = new List<MarkbookModel>();
        public List<Comments>? Comments { get; set; } = new List<Comments>();
        public Roles Role { get; set; }
        public int? BooksRead { get; set; }
        public int? CommentsMade { get; set; }
        public int? LikesGiven { get; set; }
    }
}
