using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.DTOs
{
    public class FileDto : BaseDto
    {
        public string FileName { get; set; }
        public string Storage { get; set; }

    }
}
