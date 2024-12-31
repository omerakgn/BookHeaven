using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.DTOs;
using BookHeaven.Core.Models;

namespace BookHeaven.Core.Features.Commands.AddProduct
{
    public class AddProductCommandResponse
    {
        public Book Books { get; set; }
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
