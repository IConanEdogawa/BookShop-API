using App.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Commands
{
    public class UpdateBookCommand : IRequest<ResponseModel>
    {
        public Guid Id { get; set; }
        public string? Title { get; set; }
        public string? Price { get; set; }
        public string? OriginalTitle { get; set; }
        public string? AlternativeTitle { get; set; }

        public string? Author { get; set; }
        public string? Description { get; set; }
        public string? Publisher { get; set; }

        public string? Artist { get; set; }

        public string? Translator { get; set; }

        public string? Country { get; set; }

        public string? Status { get; set; }

        public ICollection<Tag>? Tags { get; set; } = new List<Tag>();

        public ICollection<Category>? Categories { get; set; } = new List<Category>();
    }
}
