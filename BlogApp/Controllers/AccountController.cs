using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.BusinessLayer.Interfaces;
using BlogApp.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using BlogApp.Utility.Security;
using BlogApp.DTO.Common;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {
        private readonly IUserService _userService;

        public AccountController(IUserService userService)
        {
            _userService = userService;
        }

        [Route("login")]
        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginViewModel model)
        {
            var userResult = await _userService.Login(model.Email, model.Password);

            if (!userResult.IsSuccess)
            {
                return Ok(userResult);
            }

            var expireMinutes = 120;
            var token = new JwtTokenBuilder()
                        .AddSecurityKey(JwtSecurityKey.Create("BlogApp.!2019*_!"))
                        .AddSubject("BlogApp Token")
                        .AddIssuer("BlogApp.Security.Bearer")
                        .AddAudience("BlogApp.Security.Bearer")
                        .AddClaim("UserId", userResult.Result.Id.ToString())
                        .AddClaim("UserType", userResult.Result.UserType.ToString())
                        .AddExpiry(expireMinutes)
                        .Build();

            var result = new ResultDto<TokenResultViewModel>
            {
                Result = new TokenResultViewModel
                {
                    UserId = userResult.Result.Id,
                    Fullname = userResult.Result.Fullname,
                    Email = userResult.Result.Email,
                    UserType = userResult.Result.UserType,
                    Token = token.Value
                }
            };

            return Ok(result);
            
        }
    }
}