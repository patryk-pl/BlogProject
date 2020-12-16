using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Database
{
    public interface IPostRepository : IRepository<Post>
    {
        Task<Post> GetPostAsync(int id);
        Task<IEnumerable<Post>> GetAllPostsAsync();
        Task<Post> GetSinglePostAsync(int? id);
        Task<bool> EditPostAsync(Post post);
    }
}
