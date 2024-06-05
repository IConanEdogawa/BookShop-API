using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Domain.Entities.Models
{
    public class Book
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string Poster { get; set; }
        public string OriginalTitle { get; set; }
        public string AlternativeTitle { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public string Publisher { get; set; }
        public string Artist { get; set; }
        public string Translater { get; set; }
        public string Country { get; set; }
        public string Status { get; set; }



        public List<string> Tags { get; set; }
        public List<string> Categories { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime LastUpdatedDate { get; set;}
        public DateTime PublishedDate { get; set; }
        public ICollection<BookComments> Comments { get; set; }


        public long Rate { get; set; }
        public long Views { get; set; }
        public long Likes { get; set; }
        public long Saves { get; set; }
    }
}
