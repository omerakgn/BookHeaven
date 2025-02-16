using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Features.Queries.GetAllComments
{
    public class GetAllCommentsQueryResponse
    {
        public object Comments { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
        public int TotalCommentCount { get; set; }
    }
}
