using BlogProject.Database;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Core
{
    public class PostManager : IPostManager
    {
        private readonly IPostRepository _postRepository;
        private readonly PostMapper _postMapper;

        public PostManager(
            IPostRepository postRepository,
            PostMapper postMapper
            )
        {
            _postRepository = postRepository;
            _postMapper = postMapper;
        }
        public bool Add(PostDto postDto)
        {
            var entity = _postMapper.Map(postDto);
            return _postRepository.AddNew(entity);
        }
    }
}
