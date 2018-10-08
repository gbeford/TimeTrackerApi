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
using Swashbuckle.AspNetCore.Swagger;
using TimeTrackerAPI.Models;
using TimeTrackerAPI.Services;

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
            services.AddMvc()
                    .SetCompatibilityVersion(CompatibilityVersion.Version_2_1)
                    .AddJsonOptions(
                        options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
                    );

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new Info() { Title = "Time Tracker", Version = "v1" });
            });

            var database = Configuration["database"];
            var connectString = Configuration[$"ConnectionStrings:{database}"];

            switch (database)
            {
                case "MSSql":
                    services.AddEntityFrameworkSqlServer();
                    services.AddDbContext<TimeTrackerDbContext>(options => options.UseSqlServer(connectString));
                    break;
                case "postgresql":
                    services.AddEntityFrameworkNpgsql();
                    services.AddDbContext<TimeTrackerDbContext>(options => options.UseNpgsql(connectString));
                    break;
            }
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

            services.AddTransient<IStudentService, StudentService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env, TimeTrackerDbContext context)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "Time Tracker API");
                });
            }
            else
            {
                app.UseHsts();
            }

            //app.UseHttpsRedirection();


            app.UseCors("CorsPolicy");
            app.UseMvc();

            context.Database.Migrate();

        }
    }
}
