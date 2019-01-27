using System;
using BlogApp.Data.Models;
using BlogApp.Core.Enums;
using BlogApp.Core.Utility.Cryptography;
using System.Linq;
using BlogApp.Data.Infrastructure.DatabaseFactory;
using BlogApp.Data.Infrastructure;
using BlogApp.Core.Extensions;

namespace BlogApp.Data.Startup
{
    public class DatabaseInitializer
    {
        public DatabaseInitializer()
        {
            Seed();
        }
        private DataContext DbContext
        {
            get
            {
                return Activator.CreateInstance<DataContext>();
            }
            
        }

        public void Seed()
        {
            if (!DbContext.Users.Any())
            {
                DbContext.Users.Add(new User
                {
                    FirstName = "Celil",
                    LastName = "Ercan",
                    Email = "celilercan@yandex.com",
                    Photo = "test.jpg",
                    Password = StringExtensions.GenerateRandomPassword(),
                    ActivationCode = Guid.NewGuid(),
                    IsActive = true,
                    UserType = UserType.Administrator,
                    CreatedDate = DateTime.Now
                });
                DbContext.SaveChanges();
            }
        }
    }
}
