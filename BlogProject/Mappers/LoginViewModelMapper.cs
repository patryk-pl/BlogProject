using AutoMapper;
using BlogProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject
{
    public class LoginViewModelMapper
    {
        private IMapper _mapper;

        public LoginViewModelMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<LoginDto, LoginViewModel>().ReverseMap();
            }).CreateMapper();
        }
        public LoginViewModel Map(LoginDto loginDto) => _mapper.Map<LoginViewModel>(loginDto);
        public LoginDto Map(LoginViewModel loginVm) => _mapper.Map<LoginDto>(loginVm);
        public IEnumerable<LoginViewModel> Map(IEnumerable<LoginDto> loginDtos) => _mapper.Map<IEnumerable<LoginViewModel>>(loginDtos);
        public IEnumerable<LoginDto> Map(IEnumerable<LoginViewModel> loginVms) => _mapper.Map< IEnumerable<LoginDto>>(loginVms);
    }
}
