using Demo.Application.Authentication.Commons;
using MediatR;

namespace Demo.Application.Authentication.Queries.Login
{
    public record LoginQuery(string Email, string Password) : IRequest<AuthenticationResult>;

}
