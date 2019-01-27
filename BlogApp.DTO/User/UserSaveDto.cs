using BlogApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.DTO.User
{
    public class UserSaveDto
    {
        public int Id { get; set; }
        [StringLength(50,ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage ="Bu alan boş geçilemez.")]
        public string FirstName { get; set; }
        [StringLength(50, ErrorMessage = "En fazla 50 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        public string LastName { get; set; }
        [StringLength(150, ErrorMessage = "En fazla 150 karakter girebilirsiniz.")]
        [Required(ErrorMessage = "Bu alan boş geçilemez.")]
        [EmailAddress(ErrorMessage ="Geçerli bir e-posta adresi girmelisiniz.")]
        public string Email { get; set; }
        public UserType UserType { get; set; }
        public bool IsActive { get; set; }

    }
}
