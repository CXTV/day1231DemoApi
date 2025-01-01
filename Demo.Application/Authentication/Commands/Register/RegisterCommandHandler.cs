using Demo.Application.Authentication.Commons;
using Demo.Application.Common.Interfaces.Authentication;
using Demo.Application.Common.Interfaces.Persistence;
using Demo.Domain.Entities;
using MediatR;


namespace Demo.Application.Authentication.Commands.Register
{
    public class RegisterCommandHandler : IRequestHandler<RegisterCommand, AuthenticationResult>
    {

        private readonly IJwtTokenGenerator _jwtTokenGenerator;
        private readonly IUserRepository _userRepository;

        public RegisterCommandHandler(IJwtTokenGenerator jwtTokenGenerator, IUserRepository userRepository)
        {
            _jwtTokenGenerator = jwtTokenGenerator;
            _userRepository = userRepository;
        }


        public async Task<AuthenticationResult> Handle(RegisterCommand request, CancellationToken cancellationToken)
        {
            //1.查看用户是否存在
            var existingUser = _userRepository.GetUserByEmail(request.Email);
            if (existingUser != null)
            {
                throw new Exception("User already exists");
            }
            //2.创建用户
            var user = new User
            { FirstName = request.FirstName, LastName = request.LastName, Email = request.Email, Password = request.Password ,Role = request.Role};
            _userRepository.AddUser(user);
            //3.生成token
            var token = _jwtTokenGenerator.GenerateToken(user);

            return new AuthenticationResult(user, token);
        }
    }
}
