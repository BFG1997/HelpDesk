using HelpDesk.Application.Common.Interfaces;
using HelpDesk.Infrastructure.Data;
using HelpDesk.Infrastructure.Services;
using HelpDesk.Infrastructure.Settings;
using Microsoft.AspNetCore.Hosting;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using System;
using System.Collections.Generic;
using System.Text;

namespace HelpDesk.Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration, IWebHostEnvironment webHostEnvironment)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseNpgsql(configuration.GetConnectionString("DefaultConnection")));
            services.AddScoped<IApplicationDbContext>(provider => provider.GetRequiredService<ApplicationDbContext>());

            services.Configure<JwtSettings>(configuration.GetSection("Jwt"));

            // FileStorage Settings
            services.Configure<FileStorageSettings>(options =>
            {
                var relativePath = configuration["FileStorage:UploadRelativePath"] ?? "Uploads";
                options.UploadRootPath = Path.Combine(webHostEnvironment.ContentRootPath, relativePath);
            });

            services.AddScoped<IAuditService, AuditService>();  
            services.AddScoped<ICurrentUserService, CurrentUserService>();
            services.AddScoped<IDateTime, DateTimeService>();
            services.AddScoped<IFileStorageService, FileStorageService>();
            services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();
            services.AddScoped<INotificationService, NotificationService>();
            services.AddScoped<IPasswordHasher, PasswordHasher>();

            services.AddHttpContextAccessor();

            return services;
        }
    }
}
