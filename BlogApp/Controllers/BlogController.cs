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
        public IActionResult BlogList([FromBody] BlogFilterDto model)
        {
            return Ok(_blogService.GetBlogList(model));
        }

        [Route("save")]
        [HttpPost]
        public IActionResult SaveBlog([FromBody] BlogSaveDto model)
        {
            return Ok(_blogService.SaveBlog(model));
        }

        [Route("changeBlogStatus")]
        [HttpPost]
        public IActionResult ChangeStatus([FromBody] int id, bool isActive)
        {
            return Ok(_blogService.ChangeBlogStatus(id, isActive));
        }

        [Route("getBlog/{id:int}")]
        [HttpGet]
        public IActionResult GetBlogDetail(int id)
        {
            return Ok(_blogService.GetBlogById(id));
        }

        [Route("addComment")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddComment([FromBody] BlogCommentAddDto model)
        {
            return Ok(_blogService.AddBlogComment(model));
        }

        [Route("changeCommentStatus")]
        [HttpPost]
        public IActionResult ChangeCommentStatus([FromBody] int id, bool isActive)
        {
            return Ok(_blogService.ChangeBlogCommentStatus(id, isActive));
        }

        [Route("getWaitingApproveComments")]
        [HttpGet]
        public IActionResult GetWaitingApproveComments()
        {
            return Ok(_blogService.GetWaitingApproveComments());
        }
    }
}