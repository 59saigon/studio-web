using Studio.API.Business.Domain.Results.Bases;

namespace Studio.API.Business.Domain.Results.Users
{
    public class AuthResult : BaseResult
    {
        public UserResult User { get; set; }
        public string Token { get; set; }
        public string Expiration {  get; set; }
    }
}
