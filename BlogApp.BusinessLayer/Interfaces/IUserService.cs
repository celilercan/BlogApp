using BlogApp.DTO.Common;
using BlogApp.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogApp.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        ResultDto<UserDetailDto> GetDetailById(int id);
        ResultDto<List<UserListDto>> GetList();
        ResultDto<UserDetailDto> SaveUser(UserSaveDto dto);
        ResultDto<UserDetailDto> ChangeStatus(int id, bool isActive);
        ResultDto<UserDetailDto> ChangeUserPassword(ChangeUserPasswordDto dto);
        ResultDto<UserDetailDto> Login(string email, string password);
    }
}
