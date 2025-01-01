using Demo.Application.Authentication.Commons;
using Demo.Application.Common.Interfaces.Authentication;
using Demo.Application.Common.Interfaces.Persistence;
using MediatR;


namespace Demo.Application.Authentication.Queries.Login
{
    public class LoginQueryHandler : IRequestHandler<LoginQuery, AuthenticationResult>
    {
        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public LoginQueryHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }


        public async Task<AuthenticationResult> Handle(LoginQuery query, CancellationToken cancellationToken)
        {
            //1.验证用户是否存在
            var user = _userRepository.GetUserByEmail(query.Email);
            if (user == null)
            {
                throw new Exception("User not found");
            }

            //2.验证密码是否正确
            if (user.Password != query.Password)
            {
                throw new Exception("Invalid password");
            }
            //3.生成JWT token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
