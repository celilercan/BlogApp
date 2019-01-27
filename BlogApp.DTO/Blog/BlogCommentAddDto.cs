using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.DTO.Blog
{
    public class BlogCommentAddDto
    {
        [StringLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "E-Posta adresi belirtmelisiniz.")]
        [EmailAddress(ErrorMessage = "Geçerli bir e-posta adresi girmelisiniz.")]
        public string Email { get; set; }
        [StringLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Ad Soyad belirtmelisiniz.")]
        public string Fullname { get; set; }
        [Required(ErrorMessage = "Yorum alanı boş geçilemez.")]
        public string Comment { get; set; }
        public int BlogId { get; set; }
    }
}
