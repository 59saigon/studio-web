using Studio.API.Models;

namespace Studio.API.Repositories.Interfaces
{
    public interface I_RoleRepository
    {
        Role GetRole(string title); 
    }
}
