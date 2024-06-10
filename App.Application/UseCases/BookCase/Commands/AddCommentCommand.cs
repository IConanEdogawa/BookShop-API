using App.Domain.Entities.Models;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Commands
{
    public class AddCommentCommand : IRequest<ResponseModel>
    {
        public Guid BookId { get; set; }
        public Guid UserId { get; set; }
        public string Message { get; set; }
        public List<ReplyDto> Replies { get; set; }
    }

    public class ReplyDto
    {
        public Guid CommentId { get; set; }
        public Guid SenderId { get; set; }
        public string ReplyMessage { get; set; }
    }


}
