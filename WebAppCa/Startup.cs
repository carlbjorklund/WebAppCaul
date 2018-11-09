﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using WebAppCa.ViewModels;
using Microsoft.EntityFrameworkCore;
using WebAppCa.Models;

namespace WebAppCa
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection = @"Server=(localdb)\mssqllocaldb;Database=WebAppCa.BroadBadCastContext.NewDb;Trusted_Connection=True;ConnectRetryCount=0";

            //for server on azure
            //var connection =@"Server = tcp:webappca20181108112558dbserver.database.windows.net,1433; Initial Catalog = WebAppCa20181108112558_db; Persist Security Info = False; User ID = ADM; Password = Carlruhr1980; MultipleActiveResultSets = False; Encrypt = True; TrustServerCertificate = False; Connection Timeout = 30";


            services.AddDbContext<BroadCastContext>
                (options => options.UseSqlServer(connection));

            services.AddIdentity<IdentityUser, IdentityRole>().AddEntityFrameworkStores<BroadCastContext>();

           

           
            services.AddMvc();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseBrowserLink();
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseAuthentication();
            app.UseMvc();

            
            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
            });
        }
    }
}
