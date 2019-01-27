using BlogApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.Blog
{
    public class BlogFilterDto : BaseFilterDto
    {
        public bool? IsActive { get; set; }
        public int? UserId { get; set; }
        public string Keywords { get; set; }
    }
}
