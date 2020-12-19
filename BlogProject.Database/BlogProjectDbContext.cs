using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;

namespace BlogProject.Database
{
    public class BlogProjectDbContext : IdentityDbContext
    {
        public DbSet<Post> Posts { get; set; }
        public BlogProjectDbContext(DbContextOptions options) : base(options)
        {

        }
    }
}
