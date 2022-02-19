using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using stayHealthy.Api.Middleware;
using stayHealthy.DataAccess;
using stayHealthy.DataAccess.Interfaces;
using stayHealthy.DataAccess.Repositories;
using stayHealthy.Services.Interfaces;
using stayHealthy.Services.Interfaces.Utils;
using stayHealthy.Services.Mapper;
using stayHealthy.Services.Services;
using stayHealthy.Services.Services.Utils;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace stayHealthy.Api.StartupExtensions
{
    public static class ServiceCollectionExtensions
    {
        public static IServiceCollection AddDataAccessServices(this IServiceCollection services, string connectionString)
        {
            services.AddDbContext<StayHealthyContext>(options =>
                options.UseSqlServer(connectionString));
            return services;
        }

        public static IServiceCollection AddMappingServices(this IServiceCollection services)
        {
            services.AddSingleton<Profile, UserProfile>();
            services.AddSingleton<Profile, DietProfile>();
            services.AddSingleton<Profile, MealProfile>();
            services.AddSingleton<Profile, DietCategoryProfile>();
            services.AddSingleton<IConfigurationProvider, AutoMapperConfiguration>(p =>
                    new AutoMapperConfiguration(p.GetServices<Profile>()));
            services.AddSingleton<IMapper, Mapper>();
            return services;
        }

        public static IServiceCollection AddServices(this IServiceCollection services)
        {
            services.AddScoped<IDietService, DietService>();
            services.AddHttpContextAccessor();
            services.AddScoped<IHashService, HashService>();
            services.AddScoped<ITokenGeneratorService, TokenGeneratorService>();
            services.AddScoped<IAuthService, AuthService>();
            services.AddScoped<IAuthProvider, AuthProvider>();
            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ICategoryService, CategoryService>();
            return services;
        }

        public static IServiceCollection AddRepositories(this IServiceCollection services)
        {
            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<IDietRepository, DietRepository>();
            services.AddScoped<IMealRepository, MealRepository>();
            services.AddScoped<ICategoryRepository, CategoryRepository>();
            return services;
        }

        public static IServiceCollection AddValidators(this IServiceCollection services)
        {
            //services.AddScoped<IValidator<MovieCreateDto>, MovieCreateDtoValidator>();
            return services;
        }

        public static IServiceCollection AddMiddlewares(this IServiceCollection services)
        {
            services.AddScoped<ErrorHandlingMiddleware>();
            services.AddScoped<RequestTimeMiddleware>();
            return services;
        }
    }
}
