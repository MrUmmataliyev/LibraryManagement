using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Abstractions.IService
{
    public interface IBookService
    {
        public Task<string> Add(BookDTO bookDTO);
        public Task<Book> GetBookById(int id);

        public Task<List<Book>> GetAllBook(string category);

        public Task<string> GetBookSector(int ID);
        public Task<bool> Delete(int id);
        public Task<string> Update(int id, BookDTO bookDTO);
    }
}
