
using EXE201_2RE.Extensions;
using EXE201_2RE_API.Middlewares;
using EXE201_2RE_API.Models;
using EXE201_2RE_API.Service;
using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;
using System;
using static EXE201_2RE_API.Settings.ConfigurationModel;

namespace EXE201_2RE_API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddInfrastructure(builder.Configuration);

            builder.Services.AddSwaggerGen(option =>
            {
                option.SwaggerDoc("v1", new OpenApiInfo { Title = "Mock API", Version = "v1" });
                option.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    In = ParameterLocation.Header,
                    Description = "Please enter a valid token",
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    BearerFormat = "JWT",
                    Scheme = "Bearer"
                });
                option.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme
                        {
                            Reference = new OpenApiReference
                            {
                                Type=ReferenceType.SecurityScheme,
                                Id="Bearer"
                            }
                        },
                        new string[]{}
                    }
                });
            });


            builder.Services.AddCors(option =>
                option.AddPolicy("CORS", builder =>
                    builder.AllowAnyMethod().AllowAnyHeader().SetIsOriginAllowed((host) => true)));

            var app = builder.Build();

            // Hook into application lifetime events and trigger only application fully started 
            app.Lifetime.ApplicationStarted.Register(async () =>
            {
                // Database Initialiser 
            });
            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                await using (var scope = app.Services.CreateAsyncScope())
                {
                    var dbContext = scope.ServiceProvider.GetRequiredService<EXE201Context>();
                }

                app.UseSwagger();
                app.UseSwaggerUI();
            }

            //ApplyMigration(app);

            app.UseCors("CORS");

            app.UseHttpsRedirection();

            app.UseMiddleware<ExceptionMiddleware>();


            app.UseAuthentication();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }

/*        private static void ApplyMigration(WebApplication app)
        {
            using (var scope = app.Services.CreateScope())
            {
                var _db = scope.ServiceProvider.GetRequiredService<EXE201Context>();
                if (_db.Database.GetPendingMigrations().Any())
                {
                    _db.Database.Migrate();
                }
            }
        }*/
    }
}
