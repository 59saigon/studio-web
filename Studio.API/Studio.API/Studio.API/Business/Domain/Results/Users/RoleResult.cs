using Studio.API.Business.Domain.Results.Bases;

namespace Studio.API.Business.Domain.Results.Users;

public class RoleResult : BaseResult
{
    public string Title { get; set; } = null!;
        
    public string RoleName { get; set; } = null!;
        
    public ICollection<UserResult> Users { get; set; }
}