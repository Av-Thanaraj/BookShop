using log4net.Config;
using log4net;
using MediatR;
using Microsoft.EntityFrameworkCore;
using BookShop.API.Controllers;
using BookShop.Application;
using BookShop.Application.Repositories;
using BookShop.Application.UseCases.Property.Queries.GetAll;
using BookShop.Infrastructure.BaseDbContext;
using BookShop.Infrastructure.Repositories;
using log4net.Appender;
using log4net.Core;
using log4net.Layout;
using BookShop.API.Middleware;
using BookShop.Infrastructure.Services;
using BookShop.Application.Common;
using System.Text;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;

namespace BookShop.API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddLogging(loggingBuilder =>
            {
                loggingBuilder.AddLog4Net("log4net.config");
            });

            builder.Services.AddApplication();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();
            builder.Services.AddScoped<IAuthService, AuthService>();
            // Register the DbContext with the services
            builder.Services.AddDbContext<BookShopDbContext>(options =>
            options.UseSqlServer(builder.Configuration.GetConnectionString("BookShopDb")));
            builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));



            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var key = Encoding.ASCII.GetBytes(jwtSettings["SecretKey"]);

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
            .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtSettings["Issuer"],
                    ValidAudience = jwtSettings["Audience"],
                    IssuerSigningKey = new SymmetricSecurityKey(key)
                };
            });


            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            var consumer = new RabbitMqConsumer();
            consumer.StartConsuming();

            app.UseMiddleware<RequestLoggingMiddleware>();
            app.UseHttpsRedirection();

            app.UseAuthorization();


            app.MapControllers();

            app.Run();
        }
    }
}
