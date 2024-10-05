using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TechStore.Errors.Global;
using TechStore.Interfaces;
using TechStore.Services;

namespace TechStore.Extensions
{
    public static class ApplicationServiceExtensions
    {
        public static IServiceCollection AddApplicationServices(this IServiceCollection services, IConfiguration config)
        {
            services.AddControllers();
            services.AddCors();

            // Registrar los repositorios genéricos
            services.AddScoped(typeof(IRepository<>), typeof(Repository<>));


            services.AddScoped<ITokenRepository, TokenService>();
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ICustomerRepository, CustomerRepository>();
            services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());

            // Registrar el GlobalExceptionFilter
            services.AddControllers(options =>
            {
                options.Filters.Add<GlobalExceptionFilter>();
            });

            return services;
        }
    }
}