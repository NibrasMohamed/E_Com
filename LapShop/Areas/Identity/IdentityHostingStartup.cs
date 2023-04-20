using System;
using LapShop.Data;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.UI;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

[assembly: HostingStartup(typeof(LapShop.Areas.Identity.IdentityHostingStartup))]
namespace LapShop.Areas.Identity
{
    public class IdentityHostingStartup : IHostingStartup
    {
       /* public IConfiguration Configuration { get; set; }*/
        public void Configure(IWebHostBuilder builder)
        {
            builder.ConfigureServices((context, services) => {
                services.AddDbContext<AuthDbContext>(options =>
                    options.UseMySQL(context.Configuration.GetConnectionString("AuthDbContextConnection")));
            /*options.UseSqlServer(context.Configuration.GetConnectionString("AuthDbContextConnection")));*/

                services.AddDefaultIdentity<IdentityUser>(options => options.SignIn.RequireConfirmedAccount = true)
                    .AddEntityFrameworkStores<AuthDbContext>();
            });
        }
    }
}
