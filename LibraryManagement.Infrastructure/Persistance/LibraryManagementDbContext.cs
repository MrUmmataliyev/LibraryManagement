using LibraryManagement.Domain.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace LibraryManagement.Infrastructure.Persistance
{
    public class LibraryManagementDbContext : DbContext
    {
        public LibraryManagementDbContext(DbContextOptions<LibraryManagementDbContext> options)
            : base(options)
        {
            Database.Migrate();
        }

        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<Book> Books { get; set; }
    }
}
