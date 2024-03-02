using LibraryManagement.Application.Abstractions;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Application.Services.BookService;
using Microsoft.Extensions.DependencyInjection;


namespace LibraryManagement.Application
{
    public static class LibraryManagementDependencyInjection
    {
        public static IServiceCollection AddApplication(this IServiceCollection services)
        {
            services.AddScoped<IBookService, BookService>();
            return services;
        }
    }
}
