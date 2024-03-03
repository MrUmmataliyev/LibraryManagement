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

        public Task<List<Book>> GetAllBook();
        public Task<List<Book>> GetByName(string name);
        public Task<List<Book>> GetByCategory(string category);
        public Task<List<Book>> GetByAuthor(string authorName);
        public Task<List<Book>> GetBySector(string sector);
        public Task<List<Book>> GetByPublishedYear(int year);
        public Task<string> GetBookSector(int ID);
        public Task<string> Delete(int id);
        public Task<string> Update(int id, BookDTO bookDTO);
    }
}
