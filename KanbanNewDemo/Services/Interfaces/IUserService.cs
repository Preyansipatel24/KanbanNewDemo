
using KanbanNewDemo.DTOs.Users;
using KanbanNewDemo.Models.User;

namespace KanbanNewDemo.Services.Interfaces
{
    public interface IUserService
    {
        bool IsUsernameExist(string username);
        bool IsEmailExist(string email);
        void AddUser(User user);
        User LoginUser(LoginViewModel model);
        int GetUserIdByEmail(string email);
    }
}