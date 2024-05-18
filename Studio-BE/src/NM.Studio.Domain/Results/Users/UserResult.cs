using NM.Studio.Domain.Entities.Users;
using NM.Studio.Domain.Results.Bases;
using System.ComponentModel.DataAnnotations.Schema;

namespace NM.Studio.Domain.Results.Users
{
    public class UserResult : BaseResult
    {
        public string FullName { get; set; } = null!;
        
        public string? Email { get; set; }
        
        public DateTime Dob { get; set; }
        
        public string? Address { get; set; }
        
        public string? Gender { get; set; }
        
        public string Phone { get; set; } = null!;
        
        public string Username { get; set; } = null!;
        
        public Guid RoleId { get; set; }
        
        public string? Avatar { get; set; }
        
        public string? Status { get; set; }
        
        public RoleResult Role { get; set; } = null!;
    }
}
