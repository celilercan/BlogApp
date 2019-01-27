using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using BlogApp.BusinessLayer.Interfaces;
using BlogApp.Core.Enums;
using BlogApp.Core.Extensions;
using BlogApp.Core.Utility.Cryptography;
using BlogApp.Data.Infrastructure.UnitOfWork;
using BlogApp.Data.Models;
using BlogApp.DTO.Common;
using BlogApp.DTO.User;
using Omu.ValueInjecter;

namespace BlogApp.BusinessLayer.Services
{
    public class UserService : IUserService
    {
        private readonly IUnitOfWork _uow;
        private readonly IEncryptionService _encryptionService;

        public UserService(IUnitOfWork uow, IEncryptionService encryptionService)
        {
            _uow = uow;
            _encryptionService = encryptionService;
        }

        public ResultDto<UserDetailDto> ChangeStatus(int id, bool isActive)
        {
            var result = new ResultDto<UserDetailDto> { Result = new UserDetailDto() };
            var user = _uow.UserRepo.Query().FirstOrDefault(x => x.Id == id);
            if (user == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }
            user.IsActive = isActive;
            _uow.UserRepo.Commit();

            result.Result.InjectFrom(user);
            return result;
        }

        public ResultDto<UserDetailDto> ChangeUserPassword(ChangeUserPasswordDto dto)
        {
            var result = new ResultDto<UserDetailDto> { Result = new UserDetailDto() };

            if (dto.NewPassword != dto.RenewPassword)
            {
                result.ErrorType = ErrorType.PasswordsNotMatching;
                return result;
            }

            var user = _uow.UserRepo.Query().FirstOrDefault(x => x.Id == dto.Id);

            if (user == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            var encryptedNewPassword = _encryptionService.EncryptPassword(dto.CurrentPassword);

            if (user.Password != encryptedNewPassword)
            {
                result.ErrorType = ErrorType.CurrentPasswordWrong;
                return result;
            }

            user.Password = encryptedNewPassword;
            _uow.UserRepo.Commit();

            result.Result.InjectFrom(user);

            return result;
        }

        public ResultDto<UserDetailDto> GetDetailById(int id)
        {
            var result = new ResultDto<UserDetailDto> { Result = new UserDetailDto() };

            var user = _uow.UserRepo.Query().FirstOrDefault(x => x.Id == id);

            if (user == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            result.Result.InjectFrom(user);

            return result;
        }

        public ResultDto<List<UserListDto>> GetList()
        {
            var result = new ResultDto<List<UserListDto>>();

            result.Result = _uow.UserRepo.Query().Select(x => new UserListDto
            {
                Id = x.Id,
                FirstName = x.FirstName,
                LastName = x.LastName,
                Email = x.Email,
                Photo = x.Photo,
                UserType = x.UserType,
                CreatedDate = x.CreatedDate
            }).ToList();

            return result;
        }

        public ResultDto<UserDetailDto> Login(string email, string password)
        {
            var result = new ResultDto<UserDetailDto> { Result = new UserDetailDto() };

            var user = _uow.UserRepo.Query().FirstOrDefault(x => x.Email == email && x.IsActive);
            if (user == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            if (user.Password != _encryptionService.EncryptPassword(password))
            {
                result.ErrorType = ErrorType.CurrentPasswordWrong;
                return result;
            }

            result.Result.InjectFrom(user);

            return result;
        }

        public ResultDto<UserDetailDto> SaveUser(UserSaveDto dto)
        {
            var result = new ResultDto<UserDetailDto> { Result = new UserDetailDto() };

            var user = dto.Id > default(int)
                ? _uow.UserRepo.Query().FirstOrDefault(x => x.Id == dto.Id)
                : new User
                {
                    ActivationCode = Guid.NewGuid(),
                    Password = _encryptionService.EncryptPassword(StringExtensions.GenerateRandomPassword()),
                    CreatedDate = DateTime.Now
                };

            if (user == null)
            {
                result.ErrorType = ErrorType.NotFound;
                return result;
            }

            user.InjectFrom(dto);

            if (dto.Id <= default(int))
                _uow.UserRepo.Add(user);

            _uow.UserRepo.Commit();

            result.Result.InjectFrom(user);

            return result;
        }
    }
}
