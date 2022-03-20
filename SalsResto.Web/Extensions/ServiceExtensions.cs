using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using SalsResto.Data;
using SalsResto.Repository;
using SalsResto.Services.LoggerServices;

namespace SalsResto.Web.Extensions
{
    public static class ServiceExtensions
    {

        public static void ConfigureCors(this IServiceCollection service) =>
            service.AddCors(options =>
            {
                options.AddPolicy("CorsPolicy", builder =>
                    builder.AllowAnyOrigin()
                        .AllowAnyMethod()
                        .AllowAnyHeader());

            });


        public static void ConfigureIISIntegration(this IServiceCollection service) =>

            service.Configure<IISOptions>(options =>
            {

            });


        public static void ConfigureLoggerService(this IServiceCollection service) =>

            service.AddScoped<ILoggerManager, LoggerManager>();


        public static void ConfigureSqlContextConnection(this IServiceCollection services, IConfiguration configuration) =>
            services.AddDbContext<SalsApplicationDbContext>(opts =>
                opts.UseSqlServer(configuration.GetConnectionString("SqlDev_Connection"),b => b.MigrationsAssembly("SalsResto.Web")));


        public static void ConfigureRepositoryManager(this IServiceCollection services) =>
            services.AddScoped<IRepositoryManager, RepositoryManager>();

        public static void ConfigureApiBehavior(this IServiceCollection service)=>
            service.Configure<ApiBehaviorOptions>(options =>
                options.SuppressModelStateInvalidFilter = true);
    }
}
