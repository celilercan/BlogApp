using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace BlogApp.Core.Enums
{
    public enum UserType
    {
        [Display(Name = "Yönetici")]
        Administrator = 1,
        [Display(Name = "Yazar")]
        Author = 2
    }
}
