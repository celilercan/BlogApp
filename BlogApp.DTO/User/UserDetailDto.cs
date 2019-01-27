using BlogApp.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.DTO.User
{
    public class UserDetailDto
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Fullname
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        public string Photo { get; set; }
        public string Email { get; set; }
        public UserType UserType { get; set; }
    }
}
