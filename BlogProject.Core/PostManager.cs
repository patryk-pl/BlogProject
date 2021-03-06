﻿using BlogProject.Database;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using System.Linq;

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
        public async Task<bool> EditPostAsync(PostDto postDto)
        {
            var entity = _postMapper.Map(postDto);
            return await _postRepository.EditPostAsync(entity);
        }
        public async Task<bool> DeletePostAsync(PostDto postDto)
        {
            var entity = _postMapper.Map(postDto);
            return await _postRepository.Delete(entity);
        }
        public async Task<IEnumerable<PostDto>> GetAllPostAsync(string filterString)
        {
            var postEntities = await _postRepository.GetAllPostsAsync();

            
            if (!string.IsNullOrEmpty(filterString))
            {
                postEntities = postEntities.Where(x => 
                       x.Body.Contains(filterString)
                    || x.Category.Contains(filterString)
                    || x.Description.Contains(filterString)
                    || x.Tags.Contains(filterString)
                    );
            }

            return _postMapper.Map(postEntities);
        }
        public async Task<PostDto> GetSinglePostAsync(int? id)
        {
            var postEntity = await _postRepository.GetSinglePostAsync(id);
            return _postMapper.Map(postEntity);
        }
    }
}
