﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BookHeaven.Core.Models;

namespace BookHeaven.Core.Features.Commands.DeleteProductImage
{
    public class DeleteProductImageCommandResponse
    {
       
        public string Message { get; set; }
        public bool Success { get; set; }
    }
}
