using BlogApp.Data.Infrastructure.Repository;
using BlogApp.Data.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.Data.Infrastructure.UnitOfWork
{
    public interface IUnitOfWork
    {
        IRepository<User> UserRepo { get; }
        IRepository<Blog> BlogRepo { get; }
        IRepository<BlogComment> BlogCommentRepo { get; }
        IRepository<ContactForm> ContactFormRepo { get; }
    }
}
