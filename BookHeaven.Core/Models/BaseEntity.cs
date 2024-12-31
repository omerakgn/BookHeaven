﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BookHeaven.Core.Models
{
    public class BaseEntity
    {
        public int Id { get; set; }
        public DateTime? CreateDate { get; set; }
        virtual public DateTime? UpdateDate { get; set; }
    }
}
