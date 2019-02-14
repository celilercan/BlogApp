using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.BusinessLayer.Interfaces;
using BlogApp.Core.Enums;
using BlogApp.DTO.User;
using BlogApp.Utility.Attributes;
using BlogApp.Utility.Security;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "BlogAppMember")]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("getList")]
        [HttpGet]
        public async Task<IActionResult> GetList()
        {
            return Ok(await _userService.GetList());
        }

        [Route("getInfo/{id:int}")]
        [HttpGet]
        [ActionAccess(AllowedUserTypes = new[] { UserType.Administrator })]
        public async Task<IActionResult> GetUserInfo(int id)
        {
            return Ok(await _userService.GetDetailById(id));
        }

        [Route("me")]
        [HttpGet]
        [ActionAccess(AllowedUserTypes = new[] { UserType.Administrator, UserType.Author })]
        public async Task<IActionResult> GetMyInfo()
        {
            var id = User.Identity.GetUserId();
            return Ok(await _userService.GetDetailById(id));
        }

        [Route("save")]
        [HttpPost]
        [ActionAccess(AllowedUserTypes = new[] { UserType.Administrator })]
        public async Task<IActionResult> SaveUser([FromBody] UserSaveDto model)
        {
            return Ok(await _userService.SaveUser(model));
        }

        [Route("changeStatus")]
        [HttpPost]
        [ActionAccess(AllowedUserTypes = new[] { UserType.Administrator })]
        public async Task<IActionResult> ChangeUserStatus([FromBody] int id, bool isActive)
        {
            return Ok(await _userService.ChangeStatus(id, isActive));
        }

        [Route("changePassword")]
        [HttpPost]
        [ActionAccess(AllowedUserTypes = new[] { UserType.Administrator, UserType.Author })]
        public async Task<IActionResult> ChangePassword([FromBody] ChangeUserPasswordDto model)
        {
            return Ok(await _userService.ChangeUserPassword(model));
        }
    }
}