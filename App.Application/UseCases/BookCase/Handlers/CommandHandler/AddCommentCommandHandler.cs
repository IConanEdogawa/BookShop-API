using App.Application.Abstractions;
using App.Application.UseCases.BookCase.Commands;
using App.Domain.Entities.Models;
using MediatR;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace App.Application.UseCases.BookCase.Handlers.CommandHandler
{
    public class AddCommentCommandHandler : IRequestHandler<AddCommentCommand, Guid>
    {
        private readonly IAppDbContext _context;

        public AddCommentCommandHandler(IAppDbContext context)
        {
            _context = context;
        }

        public async Task<Guid> Handle(AddCommentCommand request, CancellationToken cancellationToken)
        {
            var _Id = Guid.NewGuid();
            var comment = new Comments
            {
                Id = _Id,
                CommentText = request.Message,
                BookId = request.BookId,
                UserId = request.UserId,
                CreatedDate = DateTime.UtcNow
            };

            _context.Comments.Add(comment);
            if (request.Replies != null && request.Replies.Count > 0)
            {
                foreach (var replyDto in request.Replies)
                {
                    var reply = new Reply
                    {
                        Id = _Id,
                        CommentId = comment.Id,
                        SenderId = replyDto.SenderId,
                        ReplyMessage = replyDto.ReplyMessage,
                        CreatedDate = DateTime.UtcNow
                    };
                    _context.Replies.Add(reply);
                }
            }

            await _context.SaveChangesAsync(cancellationToken);

            return comment.Id;
        }
    }

}

