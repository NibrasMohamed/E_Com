﻿using LapShop.DataBaseConnection;
using Microsoft.AspNetCore.Builder;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace LapShop
{
    public class Startup
    {
        public void Configure(IApplicationBuilder app)
        {
            // For more information on how to configure your application, visit https://go.microsoft.com/fwlink/?LinkID=398940
           

            
        }

        public void ConfigureServices(IServiceCollection services)
        {
            var config = new ConfigurationBuilder()
           .AddEnvironmentVariables()
           .Build();

            
        }

        
    }
}