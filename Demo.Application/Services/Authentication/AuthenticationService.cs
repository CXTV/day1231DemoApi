using Demo.Application.Common.Interfaces.Authentication;

namespace Demo.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;

        public AuthenticationService(IJwtTokenGenerator _jwtTokenGenerator)
        {
            this._jwtTokenGenerator = _jwtTokenGenerator;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //1.查看用户是否存在

            //2.创建用户

            //3.生成token
            Guid userId = Guid.NewGuid();
            var token = _jwtTokenGenerator.GenerateToken(userId, firstName, lastName);


            return new AuthenticationResult(Guid.NewGuid(), firstName, lastName, email, token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            return new AuthenticationResult(Guid.NewGuid(), "John", "Doe", email, "token");
        }
    }
}
