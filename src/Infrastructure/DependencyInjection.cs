using Application.Common.Interfaces;
using Application.DataAccess.Interfaces;
using Infrastructure.Services;
using Infrastructure.Settings;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Persistence.Context;
using Persistence.Entity;
using System;

namespace Infrastructure
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddMediatR(AppDomain.CurrentDomain.GetAssemblies());
            return services;
        }
        public static IServiceCollection AddInfrastructure(this IServiceCollection services)
        {
            // Add Services
            //services.AddScoped<intrface, service>();
            services.AddScoped<IMoviesDAC, MoviesService>();
            return services;
        }

        public static IServiceCollection AddPersistence(this IServiceCollection services, ConfigApp appSettings)
        {
            // Add Data Base Connection
            var sqlServer = string.Format(appSettings.DBConnection.Connection, appSettings.DBConnection.Server, appSettings.DBConnection.DataBase, appSettings.DBConnection.User, appSettings.DBConnection.Password, appSettings.DBConnection.Aditional, string.IsNullOrEmpty(appSettings.DBConnection.Port) ? "" : appSettings.DBConnection.Port.Contains(":") ? appSettings.DBConnection.Port : $":{appSettings.DBConnection.Port}");
            services.AddDbContext<MoviesContext>(options => options.UseSqlServer(sqlServer));
            services.AddScoped<IMoviesContext>(provider => provider.GetService<MoviesContext>());

            return services;
        }

        public static IServiceCollection AddUnitOfWork<TContext>(this IServiceCollection services) where TContext : DbContext
        {
            // Add Unit of Work
            services.AddScoped<IRepositoryFactory, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork, UnitOfWork<TContext>>();
            services.AddScoped<IUnitOfWork<TContext>, UnitOfWork<TContext>>();
            return services;
        }

    }
}
