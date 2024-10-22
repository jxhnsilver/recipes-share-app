using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using RecipesShare.BLL.Abstractions.Mappers;
using RecipesShare.BLL.Abstractions.Security;
using RecipesShare.BLL.Abstractions.Services;
using RecipesShare.BLL.Mappers;
using RecipesShare.BLL.Security;
using RecipesShare.BLL.Services;
using RecipesShare.DAL.Abstractions;
using RecipesShare.DAL.Context;
using RecipesShare.DAL.Repositories;
using System.Text;

namespace RecipesShare.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddDbContext<RecipesShareDbContext>(options =>
                options.UseSqlServer(builder.Configuration.GetConnectionString("RecipesShareSqlServerConnection")));

            builder.Services.AddScoped<IRecipeRepository, RecipeRepository>();
            builder.Services.AddScoped<IRecipeService, RecipeService>();
            builder.Services.AddScoped<IRecipeMapper, RecipeMapper>();

            builder.Services.AddScoped<ICategoryRepository, CategoryRepository>();
            builder.Services.AddScoped<ICategoryService, CategoryService>();
            builder.Services.AddScoped<ICategoryMapper, CategoryMapper>();

            builder.Services.Configure<JwtOptions>(builder.Configuration.GetSection("JwtOptions"));

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = builder.Configuration["JwtOptions:Issuer"],
                    ValidAudience = builder.Configuration["JwtOptions:Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["JwtOptions:SigningKey"]!))
                };
                options.Events = new JwtBearerEvents
                {
                    OnMessageReceived = contex =>
                    {
                        contex.Token = contex.Request.Cookies["my-cookies"];
                        return Task.CompletedTask;
                    }
                };
            });

            builder.Services.AddAuthorization();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IRoleRepository, RoleRepository>();
            builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();

            builder.Services.AddScoped<IAuthService, AuthService>();
            builder.Services.AddScoped<IJwtProvider, JwtProvider>();
            builder.Services.AddScoped<IPasswordHasher, PasswordHasher>();

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
