using BlogApp.Core.Extensions.PagerExtensions;
using BlogApp.DTO.Common;
using BlogApp.DTO.ContactForm;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Interfaces
{
    public interface IContactFormService
    {
        Task<ResultDto<ContactFormDetailDto>> AddContactForm(ContactFormAddDto dto);
        Task<ResultDto<ContactFormDetailDto>> GetContactFormById(int id);
        Task<ResultDto<PagedList<ContactFormDetailDto>>> GetList(BaseFilterDto filter);
        Task<bool> DeleteContactForm(int id);
    }
}
