using BlogApp.Core.Extensions.PagerExtensions;
using BlogApp.DTO.Common;
using BlogApp.DTO.ContactForm;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BusinessLayer.Interfaces
{
    public interface IContactFormService
    {
        ResultDto<ContactFormDetailDto> AddContactForm(ContactFormAddDto dto);
        ResultDto<ContactFormDetailDto> GetContactFormById(int id);
        ResultDto<PagedList<ContactFormDetailDto>> GetList(BaseFilterDto filter);
        bool DeleteContactForm(int id);
    }
}
