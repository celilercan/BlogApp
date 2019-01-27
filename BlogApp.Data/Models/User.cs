using BlogApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Data.Models
{
    public class User
    {
        public int Id { get; set; }
        [MaxLength(50)]
        [Required]
        public string FirstName { get; set; }
        [MaxLength(50)]
        [Required]
        public string LastName { get; set; }
        [MaxLength(150)]
        public string Photo { get; set; }
        [MaxLength(150)]
        [Required]
        public string Email { get; set; }
        [MaxLength(255)]
        [Required]
        public string Password { get; set; }
        public Guid ActivationCode { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }
        public DateTime CreatedDate { get; set; }
        public List<Blog> Blogs { get; set; }
    }
}
