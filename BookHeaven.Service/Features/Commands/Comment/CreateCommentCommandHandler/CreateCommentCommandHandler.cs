using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Features.Commands.Comment.CreateComments;
using BookHeaven.Core.Models;
using BookHeaven.Repository;
using MediatR;

namespace BookHeaven.Service.Features.Commands.Comment.CreateCommentCommandHandler
{
    public class CreateCommentCommandHandler : IRequestHandler<CreateCommentCommandRequest, CreateCommentCommandResponse>
    {
        private readonly AppDbContext _context;

        public CreateCommentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<CreateCommentCommandResponse> Handle(CreateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var newComment = new Core.Models.Comment
            {
                BookId = request.BookId,
                UserName = request.UserName,
                Content = request.Content,
                CreateDate = DateTime.Now
            };

            _context.Comments.Add(newComment);
            await _context.SaveChangesAsync(cancellationToken);

            return new CreateCommentCommandResponse
            {
                CommentId = newComment.Id,
                Message = "Yorum başarıyla eklendi.",
                Success = true
            };
        }
    }
}
