using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using NM.Studio.Domain.Entities.Bases;

namespace NM.Studio.Domain.Entities.Users
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        public string Title { get; set; } = null!;
        
        public string RoleName { get; set; } = null!;
        
        public virtual ICollection<User> Users { get; set; }
    }
}
