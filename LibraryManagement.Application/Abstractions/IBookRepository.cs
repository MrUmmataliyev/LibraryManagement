using LibraryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Abstractions
{
    public interface IBookRepository : IBaseRepository<Book>
    {
    }
}
