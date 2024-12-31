using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Models;
using MediatR;
using Microsoft.AspNetCore.Http;

namespace BookHeaven.Core.Features.Commands.UploadFile
{
    public class UploadFileCommandRequest : IRequest<UploadFileCommandResponse>
    {
        public int id { get; set; }
        public IFormFileCollection Files { get; set; }

        public UploadFileCommandRequest(int ProductId, IFormFileCollection files)
        {
            id = ProductId;
            Files = files;
        }
    }
}
