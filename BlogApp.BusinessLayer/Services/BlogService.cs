﻿using BlogApp.BusinessLayer.Interfaces;
using BlogApp.Core.Enums;
using BlogApp.Core.Extensions;
using BlogApp.Core.Extensions.PagerExtensions;
using BlogApp.Data.Infrastructure.UnitOfWork;
using BlogApp.Data.Models;
using BlogApp.DTO.Blog;
using BlogApp.DTO.Common;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace BlogApp.BusinessLayer.Services
{
    public class BlogService : IBlogService
    {
        private readonly IUnitOfWork _uow;

        public BlogService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public ResultDto<BlogCommentDetailDto> AddBlogComment(BlogCommentAddDto dto)
        {
            var result = new ResultDto<BlogCommentDetailDto>();

            var blogComment = new BlogComment
            {
                BlogId = dto.BlogId,
                Email = dto.Email,
                Fullname = dto.Fullname,
                Comment = dto.Comment,
                CreatedDate = DateTime.Now
            };

            _uow.BlogCommentRepo.Add(blogComment);
            _uow.BlogCommentRepo.Commit();

            result.Result.InjectFrom(blogComment);

            return result;
        }

        public ResultDto<BlogCommentDetailDto> ChangeBlogCommentStatus(int id, bool isActive)
        {
            var result = new ResultDto<BlogCommentDetailDto>();

            var blogComment = _uow.BlogCommentRepo.Query().FirstOrDefault(x => x.Id == id);

            if (blogComment == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            blogComment.IsActive = isActive;
            _uow.BlogCommentRepo.Commit();

            result.Result.InjectFrom(blogComment);

            return result;
        }

        public ResultDto<BlogDetailDto> ChangeBlogStatus(int id, bool isActive)
        {
            var result = new ResultDto<BlogDetailDto>();

            var blog = _uow.BlogRepo.Query().FirstOrDefault(x => x.Id == id);

            if (blog == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            blog.IsActive = isActive;
            _uow.BlogRepo.Commit();

            result.Result.InjectFrom(blog);

            return result;
        }

        public bool DeleteComment(int id)
        {
            var comment = _uow.BlogCommentRepo.Query().FirstOrDefault(x => x.Id == id);
            if (comment == null) return false;
            _uow.BlogCommentRepo.Delete(comment);
            _uow.BlogCommentRepo.Commit();
            return true;
        }

        public ResultDto<BlogDetailDto> GetBlogById(int id)
        {
            var result = new ResultDto<BlogDetailDto>();

            var blog = _uow.BlogRepo.Query().FirstOrDefault(x => x.Id == id);

            if (blog == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            result.Result.InjectFrom(blog);

            result.Result.CreatedDate = $"{blog.CreatedDate.ToShortDateString()} {blog.CreatedDate.ToShortTimeString()}";

            result.Result.BlogComments = blog.BlogComments != null
                ? blog.BlogComments.Select(x => new BlogCommentDetailDto
                {
                    Id = x.Id,
                    BlogId = x.BlogId,
                    UserEmail = x.Email,
                    UserFullname = x.Fullname,
                    Comment = x.Comment,
                    CreatedDate = x.CreatedDate
                }).ToList()
                : new List<BlogCommentDetailDto>();

            return result;
        }

        public ResultDto<PagedList<BlogListDto>> GetBlogList(BlogFilterDto filter)
        {
            var result = new ResultDto<PagedList<BlogListDto>>();

            var query = _uow.BlogRepo.Query()
                .AppendWhereIf(x => x.IsActive == filter.IsActive, filter.IsActive.HasValue)
                .AppendWhereIf(x => x.UserId == filter.UserId, filter.UserId.HasValue)
                .AppendWhereIf(x => x.Keywords.ToLower().Contains(filter.Keywords.ToLower()), filter.Keywords.IsNotNull())
                .OrderByDescending(x => x.CreatedDate);

            var totalCount = query.Count();

            var resultQuery = query.Page(filter.PageIndex, filter.PageSize);

            result.Result = new PagedList<BlogListDto>(resultQuery.Select(x => new BlogListDto
            {
                Id = x.Id,
                Title = x.Title,
                Photo = x.Photo,
                CommentCount = x.BlogComments.Count(y => y.IsActive),
                ViewCount = x.ViewCount,
                Keywords = x.Keywords,
                CreatedDate = x.CreatedDate
            }).ToList(), filter.PageIndex, filter.PageSize, totalCount);

            return result;
        }

        public ResultDto<List<BlogCommentDetailDto>> GetWaitingApproveComments()
        {
            var result = new ResultDto<List<BlogCommentDetailDto>>();

            result.Result = _uow.BlogCommentRepo.Query().Where(x => !x.IsActive).Select(x =>
            new BlogCommentDetailDto
            {
                Id = x.Id,
                BlogId = x.BlogId,
                UserEmail = x.Email,
                UserFullname = x.Fullname,
                Comment = x.Comment,
                CreatedDate = x.CreatedDate
            }).ToList();

            return result;
        }

        public ResultDto<BlogDetailDto> SaveBlog(BlogSaveDto dto)
        {
            var result = new ResultDto<BlogDetailDto>();

            var blog = dto.Id > default(int)
                ? _uow.BlogRepo.Query().FirstOrDefault(x => x.Id == dto.Id)
                : new Blog { CreatedDate = DateTime.Now };

            if (blog == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            blog.InjectFrom(dto);

            if (dto.Id <= default(int))
                _uow.BlogRepo.Add(blog);

            _uow.BlogRepo.Commit();

            return result;
        }
    }
}
