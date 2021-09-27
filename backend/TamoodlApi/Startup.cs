using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Configuration;
using Microsoft.EntityFrameworkCore;

using TamoodlApi.Data.Accounts;
using Microsoft.AspNetCore.Identity;
using TamoodlApi.Authentication;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using AutoMapper;
using TamoodlApi.Data.Contexts;
using TamoodlApi.Data.Students;
using TamoodlApi.Data.Courses;
using TamoodlApi.Data.Teachers;

namespace TamoodlApi
{
    public class Startup
    {
        private readonly IConfiguration _configuration;
        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }
        public void ConfigureServices(IServiceCollection services)
        {
            services.AddIdentity<IdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<UsersDbContext>();

            // Configuring JWT
            services.Configure<JWT>(_configuration.GetSection("JWT"));

            // Registering services
            services.AddScoped<IUserService, UserService>();
            // services.AddScoped<IStudentsService, StudentsService>();
            services.AddScoped<ICoursesService, CoursesService>();
            services.AddScoped<ITeachersService, TeachersService>();


            // Adding contexts
            services.AddDbContext<CoursesDbContext>(options => options.UseInMemoryDatabase(
                _configuration.GetSection("Databases")["DataDb"])
            );

            services.AddDbContext<UsersDbContext>(options => options.UseInMemoryDatabase(
                _configuration.GetSection("Databases")["UsersDb"])
            );

            // Adding JWT authentication
            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(opt =>
            {
                opt.RequireHttpsMetadata = false;
                opt.SaveToken = false;
                opt.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ClockSkew = TimeSpan.Zero,
                    ValidIssuer = _configuration["JWT:Issuer"],
                    ValidAudience = _configuration["JWT:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Key"]))
                };
            });

            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
            services.AddControllers();
        }

        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseEndpoints(ep => ep.MapControllers());
        }
    }
}
