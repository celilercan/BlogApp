using BlogApp.Core.Extensions.PagerExtensions;
using BlogApp.DTO.Blog;
using BlogApp.DTO.Common;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Interfaces
{
    public interface IBlogService
    {
        Task<ResultDto<BlogDetailDto>> SaveBlog(BlogSaveDto dto);
        Task<ResultDto<BlogDetailDto>> GetBlogById(int id);
        Task<ResultDto<BlogDetailDto>> ChangeBlogStatus(int id, bool isActive);
        Task<ResultDto<PagedList<BlogListDto>>> GetBlogList(BlogFilterDto filter);
        Task<ResultDto<BlogCommentDetailDto>> ChangeBlogCommentStatus(int id, bool isActive);
        Task<ResultDto<BlogCommentDetailDto>> AddBlogComment(BlogCommentAddDto dto);
        Task<ResultDto<List<BlogCommentDetailDto>>> GetWaitingApproveComments();
        Task<bool> DeleteComment(int id);
    }
}
