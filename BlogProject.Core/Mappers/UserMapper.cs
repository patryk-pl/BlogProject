using AutoMapper;
using BlogProject.Database;
using Microsoft.AspNetCore.Identity;
using System.Collections.Generic;

namespace BlogProject.Core
{
    public class UserMapper
    {
        private IMapper _mapper;

        public UserMapper()
        {
            _mapper = new MapperConfiguration(config => {
                config.CreateMap<IdentityUser, LoginDto>()
                      .ReverseMap();
            }).CreateMapper();
        }
        public LoginDto Map(IdentityUser identityUser) => _mapper.Map<LoginDto>(identityUser);
        public IEnumerable<LoginDto> Map(IEnumerable<IdentityUser> identityUsers) => _mapper.Map<IEnumerable<LoginDto>>(identityUsers);
        public IdentityUser Map(LoginDto userDto) => _mapper.Map<IdentityUser>(userDto);
        public IEnumerable<IdentityUser> Map(IEnumerable<PostDto> userDtos) => _mapper.Map<IEnumerable<IdentityUser>>(userDtos);
    }
}
