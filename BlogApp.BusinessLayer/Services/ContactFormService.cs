﻿using BlogApp.BusinessLayer.Interfaces;
using BlogApp.Core.Enums;
using BlogApp.Core.Extensions;
using BlogApp.Core.Extensions.PagerExtensions;
using BlogApp.Data.Infrastructure.UnitOfWork;
using BlogApp.Data.Models;
using BlogApp.DTO.Common;
using BlogApp.DTO.ContactForm;
using Omu.ValueInjecter;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Services
{
    public class ContactFormService : IContactFormService
    {
        private readonly IUnitOfWork _uow;

        public ContactFormService(IUnitOfWork uow)
        {
            _uow = uow;
        }

        public async Task<ResultDto<ContactFormDetailDto>> AddContactForm(ContactFormAddDto dto)
        {
            var result = new ResultDto<ContactFormDetailDto>();

            var contactForm = new ContactForm { CreatedDate = DateTime.Now };

            contactForm.InjectFrom(dto);

            await _uow.ContactFormRepo.AddAsync(contactForm);
            await _uow.ContactFormRepo.CommitAsync();

            result.Result.InjectFrom(contactForm);

            return result;
        }

        public async Task<bool> DeleteContactForm(int id)
        {
            var contactForm = _uow.ContactFormRepo.Query().FirstOrDefault(x => x.Id == id);
            if (contactForm == null) return false;
            await _uow.ContactFormRepo.DeleteAsync(contactForm);
            await _uow.ContactFormRepo.CommitAsync();
            return true;
        }

        public async Task<ResultDto<ContactFormDetailDto>> GetContactFormById(int id)
        {
            var result = new ResultDto<ContactFormDetailDto>();

            var contactForm = _uow.ContactFormRepo.Query().FirstOrDefault(x => x.Id == id);

            if (contactForm == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            result.Result.InjectFrom(contactForm);

            return result;
        }

        public async  Task<ResultDto<PagedList<ContactFormDetailDto>>> GetList(BaseFilterDto filter)
        {
            var result = new ResultDto<PagedList<ContactFormDetailDto>>();

            var query = _uow.ContactFormRepo.Query().OrderByDescending(x => x.CreatedDate);

            var totalCount = query.Count();

            var resultQuery = query.Page(filter.PageIndex, filter.PageSize);

            result.Result = new PagedList<ContactFormDetailDto>(resultQuery.Select(x =>
                new ContactFormDetailDto
                {
                    Id = x.Id,
                    Fullname = x.Fullname,
                    Email = x.Email,
                    PhoneCell = x.PhoneCell,
                    Subject = x.Subject,
                    Message = x.Message,
                    CreatedDate = x.CreatedDate
                }).ToList(),
                filter.PageIndex, filter.PageSize, totalCount);

            return result;

        }
    }
}
