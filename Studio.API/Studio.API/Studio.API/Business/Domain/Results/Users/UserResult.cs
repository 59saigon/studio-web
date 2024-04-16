using Studio.API.Business.Domain.Entities.Users;
using Studio.API.Business.Domain.Results.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace Studio.API.Business.Domain.Results.Users
{
    public class UserResult : BaseResult
    {
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Address { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string? Avatar { get; set; }
        public string? Status { get; set; }
        public Role Role { get; set; } = null!;
    }
}
