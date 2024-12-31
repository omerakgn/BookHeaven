using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Models;

namespace BookHeaven.Core.Features.Commands.UpdateProduct
{
    public class UpdateProductCommandResponse
    {
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
