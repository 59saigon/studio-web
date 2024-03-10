using System;
using System.Collections.Generic;

namespace Studio.API.Models
{
    public partial class Role
    {
        public Role()
        {
            Users = new HashSet<User>();
        }

        public int Id { get; set; }
        public string RoleId { get; set; } = null!;
        public string Title { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public string? CreatedBy { get; set; }
        public DateTime CreatedDate { get; set; }

        public virtual ICollection<User> Users { get; set; }
    }
}
