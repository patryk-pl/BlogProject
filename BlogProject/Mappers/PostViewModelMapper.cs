using AutoMapper;
using BlogProject.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlogProject
{
    public class PostViewModelMapper
    {
        private IMapper _mapper;

        public PostViewModelMapper()
        {
            _mapper = new MapperConfiguration(config =>
            {
                config.CreateMap<PostDto, PostViewModel>().ReverseMap();
            }).CreateMapper();
        }
        public PostViewModel Map(PostDto postDto) => _mapper.Map<PostViewModel>(postDto);
        public PostDto Map(PostViewModel postVm) => _mapper.Map<PostDto>(postVm);
        public IEnumerable<PostViewModel> Map(IEnumerable<PostDto> postDtos) => _mapper.Map<IEnumerable<PostViewModel>>(postDtos);
        public IEnumerable<PostDto> Map(IEnumerable<PostViewModel> postVms) => _mapper.Map< IEnumerable<PostDto>>(postVms);
    }
}
