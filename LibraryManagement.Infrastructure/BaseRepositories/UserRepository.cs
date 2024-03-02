using LibraryManagement.Application.Abstractions;
using LibraryManagement.Domain.Entities.Models;
using LibraryManagement.Infrastructure.Persistance;


namespace LibraryManagement.Infrastructure.BaseRepositories
{
    public class UserRepository : BaseRepository<User>, IUserRepository
    {
        public UserRepository(LibraryManagementDbContext context) : base(context) 
        {
        }
    }
}
