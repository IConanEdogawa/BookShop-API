﻿using App.Domain.Entities.Models;
using MediatR;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Commands
{
    public class CreateBookCommand : IRequest<ResponseModel>
    {
        public string Title { get; set; }
        public IFormFile Poster { get; set; }
        public string Author { get; set; }
        public string Description { get; set; }
        public List<string>? Tags { get; set; }
        public List<string>? Categories { get; set; }
    }
}
