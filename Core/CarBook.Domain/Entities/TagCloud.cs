﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Domain.Entities
{
    public class TagCloud
    {
        public int TagCloudID { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
        public Blog Blog { get; set; }
    }
}
