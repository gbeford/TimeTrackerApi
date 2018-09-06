using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using TimeTrackerAPI.Models;

namespace TimeTrackerAPI
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
            // Add framework services.
            //services.AddCors();
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_1);

            var connection = @"Server=localhost;Database=timeTracker;User Id=sa;Password=Passw0rd;";
            services.AddDbContext<TimeTrackerDbContext>(options => options.UseSqlServer(connection));
            services.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy",
                    builder => builder.AllowAnyHeader()
                        .AllowAnyMethod()
                        .AllowAnyOrigin()
                        .AllowCredentials()
                        .Build()
                );
            });
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();


            app.UseCors("CorsPolicy");
            app.UseMvc();
            //app.UseCors(b => b.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader());
          

        }
    }
}
