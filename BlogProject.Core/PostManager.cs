using BlogProject.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

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
        public async Task<bool> Add(PostDto postDto)
        {
            var entity = _postMapper.Map(postDto);
            return await _postRepository.AddNew(entity);
        }
    }
}
