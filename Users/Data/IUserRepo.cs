using System.Collections.Generic;
using Users.Models;

namespace Users.Data
{
    public interface IUserRepo
    {
        bool SaveChanges();
        IEnumerable<User> GetAllUsers();
        User GetUserById(int id);
        void CreateUser(User user);
        void UpdateUser(User user);
         void DeleteUser(User user);
    }
}