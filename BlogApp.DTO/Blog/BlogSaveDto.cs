using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.DTO.Blog
{
    public class BlogSaveDto
    {
        public int Id { get; set; }
        [StringLength(50,ErrorMessage = "En fazla 50 karakter girebilirsiniz." )]
        [Required(ErrorMessage = "Başlık alanı boş geçilemez.")]
        public string Title { get; set; }
        public string Photo { get; set; }
        public string Keywords { get; set; }
        [Required(ErrorMessage = "İçerik alanı boş geçilemez.")]
        public string Content { get; set; }
        public int UserId { get; set; }
        public bool IsActive { get; set; }
    }
}
