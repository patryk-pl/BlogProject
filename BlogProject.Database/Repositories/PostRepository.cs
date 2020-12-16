using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace BlogProject.Database
{
    public class PostRepository : BaseRepository<Post>, IPostRepository
    {
        protected override DbSet<Post> DbSet => _dbContext.Posts;

        public PostRepository(BlogProjectDbContext dbContext) : base(dbContext)
        {

        }
    }
}
