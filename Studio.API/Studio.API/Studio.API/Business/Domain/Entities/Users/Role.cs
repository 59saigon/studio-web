using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using Studio.API.Business.Domain.Entities.Bases;

namespace Studio.API.Business.Domain.Entities.Users
{
    [Table("Role")]
    public class Role : BaseEntity
    {
        public string Title { get; set; } = null!;
        public string RoleName { get; set; } = null!;
        public virtual ICollection<User> Users { get; set; }
    }
}
