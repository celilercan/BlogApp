using System;
using System.Collections.Generic;
using System.Text;
using BlogApp.Data.Infrastructure.DatabaseFactory;
using BlogApp.Data.Infrastructure.Repository;
using BlogApp.Data.Models;

namespace BlogApp.Data.Infrastructure.UnitOfWork
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly IDatabaseFactory _databaseFactory;
        private readonly IRepository<User> _userRepo;
        private readonly IRepository<Blog> _blogRepo;
        private readonly IRepository<BlogComment> _blogCommentRepo;
        private readonly IRepository<ContactForm> _contactFormRepo;

        public UnitOfWork(IDatabaseFactory databaseFactory, 
            IRepository<User> userRepo, 
            IRepository<Blog> blogRepo, 
            IRepository<BlogComment> blogCommentRepo, 
            IRepository<ContactForm> contactFormRepo)
        {
            _databaseFactory = databaseFactory;
            _userRepo = userRepo;
            _blogRepo = blogRepo;
            _blogCommentRepo = blogCommentRepo;
            _contactFormRepo = contactFormRepo;
        }

        public IRepository<User> UserRepo => _userRepo;

        public IRepository<Blog> BlogRepo => _blogRepo;

        public IRepository<BlogComment> BlogCommentRepo => _blogCommentRepo;

        public IRepository<ContactForm> ContactFormRepo => _contactFormRepo;
    }
}
