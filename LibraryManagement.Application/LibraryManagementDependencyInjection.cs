using LibraryManagement.Application.Abstractions;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Application.Services.AuthService;
using LibraryManagement.Application.Services.BookService;
using LibraryManagement.Application.Services.UserService;
using Microsoft.Extensions.DependencyInjection;


namespace LibraryManagement.Application
{
    public static class LibraryManagementDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            services.AddScoped<IAuthSevice, AuthService>();
            services.AddScoped<IUserService, UserService>();
            return services;
        }
    }

}
