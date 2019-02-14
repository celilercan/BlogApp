using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.BusinessLayer.Interfaces;
using BlogApp.Core.Enums;
using BlogApp.DTO.Blog;
using BlogApp.Utility.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "BlogAppMember")]
    public class BlogController : ControllerBase
    {
        private readonly IBlogService _blogService;

        public BlogController(IBlogService blogService)
        {
            _blogService = blogService;
        }

        [Route("getList")]
        [HttpPost]
        public async Task<IActionResult> BlogList([FromBody] BlogFilterDto model)
        {
            return Ok(await _blogService.GetBlogList(model));
        }

        [Route("save")]
        [HttpPost]
        public async Task<IActionResult> SaveBlog([FromBody] BlogSaveDto model)
        {
            return Ok(await _blogService.SaveBlog(model));
        }

        [Route("changeBlogStatus")]
        [HttpPost]
        public async Task<IActionResult> ChangeStatus([FromBody] int id, bool isActive)
        {
            return Ok(await _blogService.ChangeBlogStatus(id, isActive));
        }

        [Route("getBlog/{id:int}")]
        [HttpGet]
        public async Task<IActionResult> GetBlogDetail(int id)
        {
            return Ok(await _blogService.GetBlogById(id));
        }

        [Route("addComment")]
        [HttpPost]
        [AllowAnonymous]
        public async Task<IActionResult> AddComment([FromBody] BlogCommentAddDto model)
        {
            return Ok(await _blogService.AddBlogComment(model));
        }

        [Route("changeCommentStatus")]
        [HttpPost]
        public async Task<IActionResult> ChangeCommentStatus([FromBody] int id, bool isActive)
        {
            return Ok(await _blogService.ChangeBlogCommentStatus(id, isActive));
        }

        [Route("getWaitingApproveComments")]
        [HttpGet]
        public async Task<IActionResult> GetWaitingApproveComments()
        {
            return Ok(await _blogService.GetWaitingApproveComments());
        }
    }
}