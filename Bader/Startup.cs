using Bader.Core.Data;
using Bader.Core.Gate;
using Bader.Core.Repository;
using Bader.Core.Services;
using Bader.Infra.Gate;
using Bader.Infra.Repository;
using Bader.Infra.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Bader
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
            services.AddControllers();
            services.AddDbContext<BaderContext>();
            services.AddScoped<IAdminDoor, AdminGate>();
            services.AddScoped<IAdminService, AdminService>();
            services.AddScoped<IAdminRepository, AdminRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<IUserGate, UserGate>();
            services.AddScoped<ICharityRepository, CharityRepository>();
            services.AddScoped<ICharityService, CharityService>();
            services.AddScoped<ICharityGate, CharityGate>();
            services.AddScoped<IAuthorizationGate, AuthorizationGate>();
            services.AddScoped<IAuthorizationService, AuthorizationService>();
            services.AddScoped<IAuthorizationRepository, AuthorizationRepository>();
            
            services.AddCors(corsOptions =>
            {
                corsOptions.AddPolicy("x",
                builder =>
                {
                    builder
                       .AllowAnyMethod().AllowAnyOrigin()
                       .AllowAnyHeader().AllowCredentials().
                        WithOrigins("http://localhost:4200");
                });
            });
            services.AddSwaggerGen();
            services.AddControllers().AddNewtonsoftJson(options =>
    options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
);

        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }


            app.UseCors("x");
            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
            app.UseSwagger();
            app.UseSwaggerUI(c =>
            {
                c.SwaggerEndpoint("/swagger/v1/swagger.json", "My Test1 Api v1");
            });
        }
    }
}
