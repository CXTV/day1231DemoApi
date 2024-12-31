using Demo.Application.Common.Interfaces.Persistence;
using Demo.Domain.Entities;

//处理用数据的持久化
namespace Demo.Infrastructure.Persistence
{
    public class UserRepository : IUserRepository
    {

        private static readonly List<User> _users = new List<User>();  

        public void AddUser(User user)
        {
            _users.Add(user);
        }

        public User? GetUserByEmail(string email)
        {
            return _users.SingleOrDefault(u => u.Email == email);
        }
    }
}
