using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandRequest : IRequest<DeleteCommentCommandResponse>
    {
        public int CommentId { get; set; }
    }
}
