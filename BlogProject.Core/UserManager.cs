using BlogProject.Database;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core
{
    public class UserManager : IUserManager
    {
        //private readonly IPostRepository _postRepository;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserMapper _userMapper;

        public UserManager(
            //IPostRepository postRepository,
            UserManager<IdentityUser> usermanager,
            SignInManager<IdentityUser> signInManager,
            UserMapper userMapper
            )
        {
            _userManager = usermanager;
            _signInManager = signInManager;
            _userMapper = userMapper;
        }

        public async Task AddUser(LoginDto userDto)
        {
            var entity = _userMapper.Map(userDto);
            await _userManager.CreateAsync(entity);

        }

        public async Task<SignInResult> LoginUser(LoginDto loginDto)
        {
           // var entity = _userMapper.Map(loginDto);
            var result = await _signInManager.PasswordSignInAsync(loginDto.UserName, loginDto.Password, false, false);
            return result;
        }

        public async Task LogoutUser()
        {
            await _signInManager.SignOutAsync();
        }
        
    }
}
