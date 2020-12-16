using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Core
{
    public interface IPostManager
    {
        Task<IEnumerable<PostDto>> GetAllPostAsync();
        Task<PostDto> GetSinglePostAsync(int? id);
        Task<bool> Add(PostDto postDto);
        Task<bool> EditPostAsync(PostDto postDto);
        Task<bool> DeletePostAsync(PostDto postDto);
    }
}
