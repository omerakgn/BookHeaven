using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Features.Commands.Comment.UpdateComment;
using BookHeaven.Repository;
using MediatR;

namespace BookHeaven.Service.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandHandler : IRequestHandler<UpdateCommentCommandRequest, UpdateCommentCommandResponse>
    {
        private readonly AppDbContext _context;

        public UpdateCommentCommandHandler(AppDbContext context)
        {
            _context = context;
        }

        public async Task<UpdateCommentCommandResponse> Handle(UpdateCommentCommandRequest request, CancellationToken cancellationToken)
        {
            var comment = await _context.Comments.FindAsync(request.CommentId);

            if (comment == null)
            {
                return new UpdateCommentCommandResponse
                {
                    Message = "Yorum bulunamadı.",
                    Success = false
                };
            }

            comment.Content = request.Content;
            comment.UpdateDate = DateTime.Now;

            await _context.SaveChangesAsync(cancellationToken);

            return new UpdateCommentCommandResponse
            {
                Message = "Yorum başarıyla güncellendi.",
                Success = true
            };
        }
    }

}
