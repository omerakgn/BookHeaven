﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MediatR;

namespace BookHeaven.Core.Features.Queries.GetAllComments
{
    public class GetAllCommentsQueryRequest : IRequest<GetAllCommentsQueryResponse>
    {
        public int BookId { get; set; }  
      
    }
}
