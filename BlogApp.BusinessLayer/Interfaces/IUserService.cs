using BlogApp.DTO.Common;
using BlogApp.DTO.User;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogApp.BusinessLayer.Interfaces
{
    public interface IUserService
    {
        Task<ResultDto<UserDetailDto>> GetDetailById(int id);
        Task<ResultDto<List<UserListDto>>> GetList();
        Task<ResultDto<UserDetailDto>> SaveUser(UserSaveDto dto);
        Task<ResultDto<UserDetailDto>> ChangeStatus(int id, bool isActive);
        Task<ResultDto<UserDetailDto>> ChangeUserPassword(ChangeUserPasswordDto dto);
        Task<ResultDto<UserDetailDto>> Login(string email, string password);
    }
}
