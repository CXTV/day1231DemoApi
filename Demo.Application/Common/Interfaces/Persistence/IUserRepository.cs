using Demo.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Application.Common.Interfaces.Persistence
{
    public interface IUserRepository
    {
        User? GetUserByEmail(string email);
        void AddUser(User user);
    }
}
