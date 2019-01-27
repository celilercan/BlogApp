using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Data.Models
{
    public class Blog
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string Title { get; set; }
        [MaxLength(150)]
        public string Photo { get; set; }
        public string Content { get; set; }
        public string Keywords { get; set; }
        public int ViewCount { get; set; }
        public User User { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
        public List<BlogComment> BlogComments { get; set; }
        public DateTime CreatedDate { get; set; }
        public DateTime? UpdatedDate { get; set; }
    }
}
