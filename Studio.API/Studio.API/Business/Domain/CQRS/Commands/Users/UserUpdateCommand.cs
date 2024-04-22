using Studio.API.Business.Domain.CQRS.Commands.Base;
using Studio.API.Business.Domain.Models.Users;

namespace Studio.API.Business.Domain.CQRS.Commands.Users
{
    public class UserUpdateCommand : UpdateCommand<UserView>
    {
        public string FullName { get; set; } = null!;
        
        public string? Email { get; set; }
        
        public DateTime Dob { get; set; }
        
        public string? Address { get; set; }
        
        public string? Gender { get; set; }
        
        public string Phone { get; set; } = null!;
        
        public string Username { get; set; } = null!;
        
        public string Password { get; set; } = null!;
        
        public Guid RoleId { get; set; }
        
        public string? Avatar { get; set; }
        
        public string? Status { get; set; }
        
        public string LastUpdatedBy { get; set; }
        public DateTime? LastUpdatedDate { get; set; }
        public bool IsDeleted { get; set; }
    }
}
