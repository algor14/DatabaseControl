﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DatabaseControl
{
    class Book
    {
        internal int Id { get; set; }
        internal string Name { get; set; }
        internal string Author { get; set; }
        internal string Publisher { get; set; }
        internal int Year { get; set; }
        internal int? UserId { get; set; }

        public override string ToString()
        {
            return $"Id:{Id}; Name:{Name}; Author:{Author}; Publisher:{Publisher}; Year:{Year}; UserId:{UserId}";
        }
    }
}