﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarBook.Dto.TagCloudDtos
{
    public class GetByBlogIdTagCloudDto
    {
        public int TagCloudID { get; set; }
        public int BlogId { get; set; }
        public string Title { get; set; }
    }
}
