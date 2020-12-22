using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BlogProject.Database
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        protected override DbSet<Post> DbSet => _dbContext.Posts;

        public PostRepository(BlogProjectDbContext dbContext) : base(dbContext)
        {

        }
        public async Task<Post> GetPostAsync(int id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<IEnumerable<Post>> GetAllPostsAsync()
        {
            return await DbSet.Select(x => x).ToListAsync();
        }
        public async Task<Post> GetSinglePostAsync(int? id)
        {
            return await DbSet.FirstOrDefaultAsync(x => x.Id == id);
        }
        public async Task<bool> EditPostAsync(Post post)
        {
            var foundEntity = await DbSet.FirstOrDefaultAsync(x => x.Id == post.Id);
            if (foundEntity != null)
            {
                foundEntity.Title = post.Title;
                foundEntity.Body = post.Body;
                foundEntity.Image = post.Image;

                return await SaveChangesAsync();
            }
            return false;
        }
    }
}
