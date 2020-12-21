using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core
{
    public interface IUserManager
    {
        Task AddUser(LoginDto userDto);
        Task<SignInResult> LoginUser(LoginDto loginDto);
        Task LogoutUser();
    }
}
