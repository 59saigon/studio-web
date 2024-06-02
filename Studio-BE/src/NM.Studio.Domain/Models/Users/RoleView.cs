using NM.Studio.Domain.Models.Base;

namespace NM.Studio.Domain.Models.Users;

public class RoleView : BaseView
{
    public string Title { get; set; } = null!;
        
    public string RoleName { get; set; } = null!;
}