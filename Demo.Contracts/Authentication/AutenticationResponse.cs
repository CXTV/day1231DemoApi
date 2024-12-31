
//返回给客户端的身份验证响应
namespace Demo.Contracts.Authentication
{
    public record AuthenticationResponse(
        Guid Id,
        string FirstName,
        string LastName,
        string Email,
        string Token);
}
