using Microsoft.EntityFrameworkCore;
using System;

namespace BlogProject.Database
{
    public class BlogProjectDbContext : DbContext
    {
        public DbSet<Post> Posts { get; set; }
        public BlogProjectDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
