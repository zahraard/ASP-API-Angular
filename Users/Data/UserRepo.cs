using System.Collections.Generic;
using System.Linq;
using Users.Models;

namespace Users.Data
{
    public class UserRepo : IUserRepo
    {
        private readonly UserContext _context;
        public UserRepo(UserContext context)
        {
            _context = context;

        }

        public void CreateUser(User user)
        {
             _context.Users.Add(user);
        }

        public void DeleteUser(User user)
        {
            _context.Users.Remove(user);
        }

        public IEnumerable<User> GetAllUsers()
        {
            //call to db and read all users
            return _context.Users.ToList();
        }

        public User GetUserById(int id)
        {
            return _context.Users.FirstOrDefault(p => p.Id == id);
        }

        public bool SaveChanges()
        {
            return (_context.SaveChanges() >= 0);
        }

        public void UpdateUser(User userData)
        {
            //do nothing
        }
    }
}