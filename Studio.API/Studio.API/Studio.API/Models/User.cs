using System;
using System.Collections.Generic;

namespace Studio.API.Models
{
    public partial class User
    {
        public User()
        {
            Moments = new HashSet<Moment>();
        }

        public int Id { get; set; }
        public Guid UserId { get; set; }
        public string FullName { get; set; } = null!;
        public string Email { get; set; } = null!;
        public DateTime Dob { get; set; }
        public string Address { get; set; } = null!;
        public string Gender { get; set; } = null!;
        public string Phone { get; set; } = null!;
        public string Username { get; set; } = null!;
        public string Password { get; set; } = null!;
        public Guid RoleId { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }
        public string? Avatar { get; set; }
        public string? Status { get; set; }

        public virtual Role Role { get; set; } = null!;
        public virtual ICollection<Moment> Moments { get; set; }
    }
}
