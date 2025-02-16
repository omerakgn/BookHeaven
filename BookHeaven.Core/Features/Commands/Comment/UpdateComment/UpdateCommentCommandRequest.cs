using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Commands.Comment.UpdateComment
{
    public class UpdateCommentCommandRequest : IRequest<UpdateCommentCommandResponse>
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
    }

}
