using Demo.Application.Common.Interfaces.Authentication;
using Demo.Application.Common.Interfaces.Persistence;
using Demo.Domain.Entities;

namespace Demo.Application.Services.Authentication
{
    public class AuthenticationService : IAuthenticationService
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public AuthenticationService(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            this._jwtTokenGenerator = jwtTokenGenerator;
            this._userRepository = userRepository;
        }

        public AuthenticationResult Register(string firstName, string lastName, string email, string password)
        {
            //1.查看用户是否存在
            var existingUser = _userRepository.GetUserByEmail(email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }
            //2.创建用户
            var user = new User { FirstName = firstName,LastName = lastName, Email =email,Password = password};
            _userRepository.AddUser(user);
            //3.生成token
            var token = _jwtTokenGenerator.GenerateToken(user);
            return new AuthenticationResult(user, token);
        }

        public AuthenticationResult Login(string email, string password)
        {
            //1.验证用户是否存在
            var user = _userRepository.GetUserByEmail(email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            //2.验证密码是否正确
            if (user.Password != password)
            {
                throw new Exception("Invalid password");
            }
            //3.生成JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user,token);
        }
    }
}
