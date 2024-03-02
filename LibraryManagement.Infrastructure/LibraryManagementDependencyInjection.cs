using LibraryManagement.Application.Abstractions;
using LibraryManagement.Domain.Entities.Models;
using LibraryManagement.Infrastructure.BaseRepositories;
using LibraryManagement.Infrastructure.Persistance;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace LibraryManagement.Infrastructure
{
    public static class LibraryManagementDependencyInjection
    {
        public static IServiceCollection AddInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddDbContext<LibraryManagementDbContext>(options =>
            {
                options.UseNpgsql(configuration.GetConnectionString("LibraryManagementConnectionString"));
            });
            services.AddScoped<IBaseRepository<User>, BaseRepository<User>>();
            services.AddScoped<IBookRepository, BookRepository>();
            services.AddScoped<IUserRepository, UserRepository>();
            return services;

        }

    }
}
