using Studio.API.Models;

namespace Studio.API.Repositories.Interfaces
{
    public interface I_UserRepository
    {
        ICollection<User> GetUsers();
        User GetUser(string userId);
        //User GetUser(string name);
        //User GetUserTrimToUpper(UserDto UserCreate);
        //decimal GetUserRating(int pokeId);
        bool UserExists(int pokeId);
        bool CreateUser(User User);
        bool UpdateUser(int ownerId, int categoryId, User User);
        bool DeleteUser(User User);
        bool Save();
    }
}
