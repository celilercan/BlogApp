using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.ContactForm
{
    public class ContactFormDetailDto
    {
        public int Id { get; set; }
        public string Fullname { get; set; }
        public string Email { get; set; }
        public string PhoneCell { get; set; }
        public string Subject { get; set; }
        public string Message { get; set; }
        public DateTime CreatedDate { get; set; }
    }
}
