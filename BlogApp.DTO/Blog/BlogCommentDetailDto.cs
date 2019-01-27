using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.Blog
{
    public class BlogCommentDetailDto
    {
        public int Id { get; set; }
        public int BlogId { get; set; }
        public string Comment { get; set; }
        public string UserEmail { get; set; }
        public string UserFullname { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
