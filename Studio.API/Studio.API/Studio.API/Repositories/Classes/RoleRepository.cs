using Studio.API.Models;
using Studio.API.Repositories.Interfaces;

namespace Studio.API.Repositories.Classes
{
    public class RoleRepository : I_RoleRepository
    {
        private readonly StudioContext _studioContext;
        public Role GetRole(string title)
        {
            return _studioContext.Roles.Where(r => r.Title == title).FirstOrDefault();
        }
    }
}
