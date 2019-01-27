using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogApp.BusinessLayer.Interfaces;
using BlogApp.Core.Enums;
using BlogApp.DTO.Common;
using BlogApp.DTO.ContactForm;
using BlogApp.Utility.Attributes;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BlogApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Policy = "BlogAppMember")]
    public class ContactFormController : ControllerBase
    {
        private readonly IContactFormService _contactFormService;

        public ContactFormController(IContactFormService contactFormService)
        {
            _contactFormService = contactFormService;
        }

        [Route("add")]
        [HttpPost]
        [AllowAnonymous]
        public IActionResult AddContactForm([FromBody] ContactFormAddDto model)
        {
            return Ok(_contactFormService.AddContactForm(model));
        }

        [Route("getList")]
        [HttpGet]
        [ActionAccess(AllowedUserTypes = new[] { UserType.Administrator })]
        public IActionResult GetList(BaseFilterDto model)
        {
            return Ok(_contactFormService.GetList(model));
        }

        [Route("getbyid/{id:int}")]
        [HttpGet]
        [ActionAccess(AllowedUserTypes = new[] { UserType.Administrator })]
        public IActionResult GetById(int id)
        {
            return Ok(_contactFormService.GetContactFormById(id));
        }
        
        [HttpDelete("{id}")]
        [ActionAccess(AllowedUserTypes = new[] { UserType.Administrator })]
        public IActionResult Delete(int id)
        {
            return Ok(_contactFormService.DeleteContactForm(id));
        }

    }
}