using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Data.Models
{
    public class BlogComment
    {
        public int Id { get; set; }
        public Blog Blog { get; set; }
        public int BlogId { get; set; }
        [MaxLength(150)]
        [Required]
        public string Fullname { get; set; }
        [MaxLength(250)]
        [Required]
        public string Email { get; set; }
        [MaxLength(500)]
        [Required]
        public string Comment { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
