using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Data.Models
{
    public class ContactForm
    {
        public int Id { get; set; }
        [MaxLength(150)]
        [Required]
        public string Fullname { get; set; }
        [MaxLength(150)]
        public string Email { get; set; }
        [MaxLength(50)]
        [Required]
        public string PhoneCell { get; set; }
        [MaxLength(50)]
        [Required]
        public string Subject { get; set; }
        [MaxLength(500)]
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
