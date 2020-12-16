using AutoMapper;
using BlogProject.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core
{
    public class PostMapper
    {
        private IMapper _mapper;

        public PostMapper()
        {
            _mapper = new MapperConfiguration(config => {
                config.CreateMap<Post, PostDto>()
                      .ReverseMap();
            }).CreateMapper();
        }
        public PostDto Map(Post postEntity) => _mapper.Map<PostDto>(postEntity);
        public IEnumerable<PostDto> Map(IEnumerable<Post> postEntities) => _mapper.Map<IEnumerable<PostDto>>(postEntities);
        public Post Map(PostDto postDto) => _mapper.Map<Post>(postDto);
        public IEnumerable<Post> Map(IEnumerable<PostDto> postDtos) => _mapper.Map<IEnumerable<Post>>(postDtos);
    }
}
