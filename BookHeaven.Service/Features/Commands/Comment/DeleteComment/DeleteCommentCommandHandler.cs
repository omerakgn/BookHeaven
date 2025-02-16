using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Features.Commands.Comment.DeleteComment;
using BookHeaven.Repository;
using MediatR;

namespace BookHeaven.Service.Features.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandHandler : IRequestHandler<DeleteCommentCommandRequest, DeleteCommentCommandResponse>
    {
        private readonly AppDbContext _context;

        public DeleteCommentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<DeleteCommentCommandResponse> Handle(DeleteCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(request.CommentId);

            if (comment == null)
            {
                return new DeleteCommentCommandResponse
                {
                    Message = "Yorum bulunamadı.",
                    Success = false
                };
            }

            _context.Comments.Remove(comment);
            await _context.SaveChangesAsync(cancellationToken);

            return new DeleteCommentCommandResponse
            {
                Message = "Yorum başarıyla silindi.",
                Success = true
            };
        }
    }

}
