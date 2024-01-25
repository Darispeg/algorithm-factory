using BussinesLayer.Service;
using DataLayer;
using DataLayer.Entities;
using DataLayer.Generic;
using DataLayer.Infraestructure;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace BussinesLayer
{
    public static class DependencyInjection
    {
        public static IServiceCollection RegisterResources(this IServiceCollection services, string dbConnection)
        {
            services.AddDbContext<ApplicationDbContext>(options => options.UseSqlServer(dbConnection, b => b.MigrationsAssembly("DataLayer")));
            services.AddScoped<DbContext, ApplicationDbContext>();

            services.AddScoped<IRepository<ApplicationDbContext, RequestEntity>, GenericRepository<ApplicationDbContext, RequestEntity>>();
            services.AddScoped<IAlgorithmService, AlgorithmService>();

            return services;
        }
    }
}
