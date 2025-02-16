using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Commands.Comment.CreateComments
{
    public class CreateCommentCommandRequest : IRequest<CreateCommentCommandResponse>
    {
        public int BookId { get; set; }
        public string UserName { get; set; }
        public string Content { get; set; }

    }
}
