using Studio.API.Business.Domain.Models.Base;

namespace Studio.API.Business.Domain.Models.Users;

public class RoleView : BaseView
{
    public string Title { get; set; } = null!;
        
    public string RoleName { get; set; } = null!;
}