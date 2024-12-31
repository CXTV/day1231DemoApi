using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Demo.Contracts.Authentication
{
    //注册请求
    public record RegisterRequest(
        string FirstName,
        string LastName,
        string Email,
        string Password);
}
