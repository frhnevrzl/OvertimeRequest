using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.IdentityModel.Tokens;
using OvertimeRequest.Context;
using OvertimeRequest.Repository.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OvertimeRequest
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
            services.AddCors(c =>
            {
                //c.AddPolicy("AllowOrigin", options => options.AllowAnyOrigin());
                c.AddPolicy("AllowOrigin", options => options.WithOrigins("https://localhost:44308").AllowAnyMethod().AllowCredentials().AllowAnyHeader());
            });

            services.AddControllers();

            services.AddDbContext<MyContext>(options => options.UseLazyLoadingProxies()
               .UseSqlServer(Configuration.GetConnectionString("OvertimeRequest")));
            services.AddAuthentication(auth =>
            {
                auth.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                auth.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(options =>
            {
                options.RequireHttpsMetadata = false;
                options.SaveToken = true;
                options.TokenValidationParameters = new TokenValidationParameters()
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidAudience = Configuration["Jwt:Audience"],
                    ValidIssuer = Configuration["Jwt:Issuer"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
                };
            });

            services.AddControllers()
            .AddNewtonsoftJson(options =>
             options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);

            services.AddScoped<EmployeeRepository>();
            services.AddScoped<AccountRepository>();
            services.AddScoped<AccountRoleRepository>();
            services.AddScoped<DepartmentRepository>();
            services.AddScoped<OvertimeApplyEmployeeRepository>();
            services.AddScoped<OvertimeApplyRepository>();
            services.AddScoped<RolesRepository>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            //app.UseCors(options => options.WithOrigins("https://localhost:44308"));
            app.UseCors("AllowOrigin");
            app.UseAuthentication();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
