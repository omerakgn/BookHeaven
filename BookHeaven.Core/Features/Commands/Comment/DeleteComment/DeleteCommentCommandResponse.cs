using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Features.Commands.Comment.DeleteComment
{
    public class DeleteCommentCommandResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
