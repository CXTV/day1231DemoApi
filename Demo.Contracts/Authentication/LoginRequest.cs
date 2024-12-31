

namespace Demo.Contracts.Authentication
{
    //登录请求
    public record LoginRequest(
        string Email,
        string Password);
}
