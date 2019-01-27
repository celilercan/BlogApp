using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.Blog
{
    public class BlogListDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Keywords { get; set; }
        public int ViewCount { get; set; }
        public int CommentCount { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
