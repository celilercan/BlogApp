using BlogApp.Core.Extensions.PagerExtensions;
using BlogApp.DTO.Blog;
using BlogApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BusinessLayer.Interfaces
{
    public interface IBlogService
    {
        ResultDto<BlogDetailDto> SaveBlog(BlogSaveDto dto);
        ResultDto<BlogDetailDto> GetBlogById(int id);
        ResultDto<BlogDetailDto> ChangeBlogStatus(int id, bool isActive);
        ResultDto<PagedList<BlogListDto>> GetBlogList(BlogFilterDto filter);
        ResultDto<BlogCommentDetailDto> ChangeBlogCommentStatus(int id, bool isActive);
        ResultDto<BlogCommentDetailDto> AddBlogComment(BlogCommentAddDto dto);
        ResultDto<List<BlogCommentDetailDto>> GetWaitingApproveComments();
        bool DeleteComment(int id);
    }
}
