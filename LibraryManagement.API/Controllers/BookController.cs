using LibraryManagement.API.Attributes;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Enums;
using LibraryManagement.Domain.Entities.Models;
using LibraryManagement.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }


        [HttpPost]
        [IdentityFilter(Permission.AddBook)]
        public async Task<string> AddBook(BookDTO model)
        {
            var result = await _bookService.Add(model);

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByBookId)]
        public async Task<Book> GetByBookId(int id)
        {
            return await _bookService.GetBookById(id);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetSector)]
        public async Task<string> GetSector(int id)
        {
            return await _bookService.GetBookSector(id);
        }

        [HttpGet]
        [IdentityFilter(Permission.GetAllBook)]
        public async Task<List<Book>> GetAllBook()
        {
            var result = await _bookService.GetAllBook();

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByBookName)]
        public async Task<List<Book>> GetByBookName(string Name)
        {
            var result = await _bookService.GetByName(Name);

            return result;
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByCategory)]
        public async Task<List<Book>> GetByCategory(string catergory)
        {
            return await _bookService.GetByCategory(catergory);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByPublishedYear)]
        public async Task<List<Book>> GetByPublishedYear(int year)
        {
            return await _bookService.GetByPublishedYear(year);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetBySector)]
        public async Task<List<Book>> GetBySector(string sector)
        {
            return await _bookService.GetBySector(sector);
        }
        [HttpGet]
        [IdentityFilter(Permission.GetByAuthor)]
        public async Task<List<Book>> GetByAuthor(string author)
        {
            return await _bookService.GetByAuthor(author);
        }

        [HttpPut]
        [IdentityFilter(Permission.UpdateBook)]
        public async Task<string> UpdateBook(int id, BookDTO bookDTO)
        {
            return await _bookService.Update(id, bookDTO);
        }
        [HttpDelete]
        [IdentityFilter(Permission.DeleteBook)]
        public async Task<string> DeleteBook(int id)
        {
            return await _bookService.Delete(id);
        }

    }
}
