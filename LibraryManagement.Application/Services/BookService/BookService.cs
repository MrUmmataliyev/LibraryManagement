using LibraryManagement.Application.Abstractions;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Application.Services.BookService
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<string> Add(BookDTO bookDTO)
        {
            var book = new Book()
            {
                BookName = bookDTO.BookName,
                AuthorName = bookDTO.AuthorName,
                Category = bookDTO.Category,
                BookShelfSector = bookDTO.BookShelfSector,
                PublishedYear = bookDTO.PublishedYear
            };

            if(book != null)
            {
                return "Added";
            }
            return "Failed";
        }

        public async Task<bool> Delete(int id)
        {
            var result =await _bookRepository.Delete(x => x.ID == id);
            return result;
        }

        public async Task<List<Book>> GetAllBook(string category)
        {
            var result = await _bookRepository.GetAll();
            return result.ToList();
        }



        public async Task<Book> GetBookById(int id)
        {
            var result = await _bookRepository.GetByAny(x=>x.ID == id);
            return result;
        }



        public async Task<string> GetBookSector(int ID)
        {
            var result = await _bookRepository.GetByAny(x=> x.ID== ID);
            return result.BookShelfSector;
        }

        public async Task<string> Update(int id, BookDTO bookDTO)
        {
            var res = await _bookRepository.GetByAny(x=> x.ID == id);
            
            if(res != null)
            {
                var user = new Book()
                {
                    BookName = bookDTO.BookName,
                    AuthorName = bookDTO.AuthorName,
                    BookShelfSector = bookDTO.BookShelfSector,
                    Category = bookDTO.Category,
                    PublishedYear = bookDTO.PublishedYear,
                };

                var result = await _bookRepository.Update(user);
                if(result != null)
                {
                    return "Updated";
                }
                return "Failed";
            }
            return "Failed";
        }

       
    }
}
