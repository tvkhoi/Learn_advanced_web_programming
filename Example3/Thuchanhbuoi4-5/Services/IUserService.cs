using System.Collections.Generic;
using Thuchanhbuoi4_5.Models;

namespace Thuchanhbuoi4_5.Services
{
    public interface IUserService
    {
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
        void DeleteUser(int id);
    }

}
