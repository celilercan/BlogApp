using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.DTO.ContactForm
{
    public class ContactFormAddDto
    {
        [StringLength(150,ErrorMessage ="En fazla 150 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Fullname { get; set; }
        [StringLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz.")]
        [EmailAddress(ErrorMessage ="Geçerli bir e-posta adresi girmelisiniz.")]
        public string Email { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string PhoneCell { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Subject { get; set; }
        [StringLength(500, ErrorMessage = "En fazla 500 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string Message { get; set; }
    }
}
