using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace App.Domain.Entities.Models
{
    public class Book
    {
        [Key]
        public Guid Id { get; set; }

        [Required]
        [MaxLength(255)]
        public string Title { get; set; }

        public string PosterUrl { get; set; }

        [MaxLength(255)]
        public string OriginalTitle { get; set; }

        [MaxLength(255)]
        public string? AlternativeTitle { get; set; }

        [Required]
        [MaxLength(255)]
        public string Author { get; set; }

        [MaxLength(2000)]
        public string Description { get; set; }

        [MaxLength(255)]
        public string? Publisher { get; set; }

        [MaxLength(255)]
        public string? Artist { get; set; }

        [MaxLength(255)]
        public string? Translator { get; set; }

        [MaxLength(255)]
        public string? Country { get; set; }

        [MaxLength(100)]
        public string? Status { get; set; }

        // Связь с тегами
        public ICollection<Tag>? Tags { get; set; } = new List<Tag>();

        // Связь с категориями
        public ICollection<Category>? Categories { get; set; } = new List<Category>();

        [DataType(DataType.DateTime)]
        public DateTime? CreatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? LastUpdatedDate { get; set; }

        [DataType(DataType.DateTime)]
        public DateTime? PublishedDate { get; set; }

        // Связь с комментариями
        public ICollection<Comments>? Comments { get; set; } = new List<Comments>();

        // Статистика книги
        public long? Rate { get; set; }
        public long? Views { get; set; }
        public long? Likes { get; set; }
        public long? Saves { get; set; }
    }
}
