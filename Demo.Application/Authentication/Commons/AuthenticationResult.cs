using Demo.Domain.Entities;


namespace Demo.Application.Authentication.Commons
{
    public record AuthenticationResult(
        User User,
        string Token);
}
