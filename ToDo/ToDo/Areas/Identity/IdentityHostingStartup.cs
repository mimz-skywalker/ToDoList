using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ToDo.Areas.Identity.Data;
using ToDo.Data;

[assembly: HostingStartup(typeof(ToDo.Areas.Identity.IdentityHostingStartup))]
namespace ToDo.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseSqlServer(
                        context.Configuration.GetConnectionString("AuthDbContextConnection")));

                services.AddDefaultIdentity<ToDoUser>(options => 
                {

                    options.SignIn.RequireConfirmedAccount = false;

                    //Password Requirements
                    options.Password.RequireDigit = true;
                    options.Password.RequireLowercase = true;
                    options.Password.RequireNonAlphanumeric = true;
                    options.Password.RequiredUniqueChars = 1;
                    options.Password.RequiredLength = 6;

                })
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}