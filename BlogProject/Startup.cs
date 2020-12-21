using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using BlogProject.Core;
using BlogProject.Database;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace BlogProject
{
    public class Startup
    {
        public IConfiguration Configuration { get;}
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }
        // This method gets called by the runtime. Use this method to add services to the container.
        // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllersWithViews();
            services.AddRazorPages();



            services.AddDbContext<BlogProjectDbContext>(options =>
            options.UseSqlServer(
                Configuration.GetConnectionString("DefaultConnection")
                ));


            services.AddIdentity<IdentityUser, IdentityRole>(options => 
            {
                options.Password.RequireDigit = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
                options.Password.RequiredLength = 6;
            })
                //.AddRoles<IdentityRole>()
                .AddEntityFrameworkStores<BlogProjectDbContext>();


            services.ConfigureApplicationCookie(options => { options.LoginPath = "/Identity/Auth/Login"; });


                services.AddTransient<IPostRepository, PostRepository>();

            //DTO mappers
            services.AddTransient<PostMapper>();
            services.AddTransient<UserMapper>();

            //View Model mappers
            services.AddTransient<PostViewModelMapper>();
            services.AddTransient<LoginViewModelMapper>();

            services.AddTransient<IPostManager, PostManager>();
            services.AddTransient<IUserManager, UserManager>();


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseAuthentication();
            app.UseRouting();
            app.UseAuthorization(); //necessary to use services.ConfigureApplicationCookie 


            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name:"default",
                    pattern:"{area=Customer}/{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
