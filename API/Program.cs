using Application.Exceptions;
using Application.Handler;
using Application.Helpers;
using Infrastructure.DAO.Implements;
using Infrastructure.DAO.Interfaces;
using Infrastructure.Data;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Reflection;
using System.Text;

namespace API
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();

            // DB context
            builder.Services.AddDbContext<MovieTheaterContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")).UseLazyLoadingProxies())
                ;

            // Register UnitOfWork
            builder.Services.AddScoped(typeof(IUnitOfWork), typeof(UnitOfWork));

            // Register Dao
            builder.Services.AddScoped(typeof(IRefreshTokenDao), typeof(RefreshTokenDao));

            // Regiser MediatR
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));
            builder.Services.AddMediatR(options => options.RegisterServicesFromAssembly(typeof(BaseHandler).Assembly));

            // HttpContextAccessor
            builder.Services.AddHttpContextAccessor();
            builder.Services.AddScoped<IUserIdentity, UserIdentity>();

            // Config JWT authentication
            var jwtSettings = builder.Configuration.GetSection("JwtSettings");
            var key = jwtSettings["SecretKey"];
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
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key))
                };
            });

            // Register Helpers
            builder.Services.AddSingleton<JwtHelper>();

            builder.Services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "Your API", Version = "v1" });

                // Add security definition for Bearer token
                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "Enter 'Bearer' followed by your token"
                });

                // Add global security requirement for Bearer token
                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });


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

            //app.UseExceptionHandler(errorApp =>
            //{
            //    errorApp.Run(async context =>
            //    {
            //        var exception = context.Features.Get<IExceptionHandlerFeature>()?.Error;
            //        if (exception.InnerException is UnauthorizedException)
            //        {
            //            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
            //            await context.Response.WriteAsJsonAsync(exception.Message);
            //        }
            //        else
            //        {
            //            context.Response.StatusCode = StatusCodes.Status400BadRequest;
            //            await context.Response.WriteAsJsonAsync(exception.Message);
            //        }
            //    });
            //});

            app.Run();
        }
    }
}