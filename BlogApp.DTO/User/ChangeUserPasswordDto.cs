using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.DTO.User
{
    public class ChangeUserPasswordDto
    {
        public int Id { get; set; }
        [MaxLength(255,ErrorMessage ="En fazla 255 karakter girebilirsiniz.")]
        [Required(ErrorMessage ="Mevcut şifre zorunludur.")]
        public string CurrentPassword { get; set; }
        [MaxLength(255, ErrorMessage = "En fazla 255 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Yeni şifre zorunludur.")]
        public string NewPassword { get; set; }
        [MaxLength(255, ErrorMessage = "En fazla 255 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Yeni şifre tekrarı zorunludur.")]
        public string RenewPassword { get; set; }
    }
}
