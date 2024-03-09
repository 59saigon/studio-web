using Studio.API.Models;
using Studio.API.Repositories.Interfaces;

namespace Studio.API.Repositories.Classes
{
    public class UserRepository : I_UserRepository
    {
        private readonly StudioContext _context;
        public bool CreateUser(User User)
        {
            throw new NotImplementedException();
        }

        public bool DeleteUser(User User)
        {
            throw new NotImplementedException();
        }

        public User GetUser(string userId)
        {
            return _context.Users.Where(u => u.UserId.ToString().ToUpper() == userId.ToUpper()).FirstOrDefault();
        }

        public ICollection<User> GetUsers()
        {
            throw new NotImplementedException();
        }

        public bool Save()
        {
            throw new NotImplementedException();
        }

        public bool UpdateUser(int ownerId, int categoryId, User User)
        {
            throw new NotImplementedException();
        }

        public bool UserExists(int pokeId)
        {
            throw new NotImplementedException();
        }
    }
}
