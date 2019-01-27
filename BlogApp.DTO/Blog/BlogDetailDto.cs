using BlogApp.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.Blog
{
    public class BlogDetailDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Keywords { get; set; }
        public string Content { get; set; }
        public int ViewCount { get; set; }
        public UserSummaryDetailDto Author { get; set; }
        public bool IsActive { get; set; }
        public List<BlogCommentDetailDto> BlogComments { get; set; }
        public string CreatedDate { get; set; }
    }
}
