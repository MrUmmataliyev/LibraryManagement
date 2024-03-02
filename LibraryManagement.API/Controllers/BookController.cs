using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Models;
using LibraryManagement.Domain.Entities.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace LibraryManagement.API.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class BookController : ControllerBase
    {
        private readonly IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }
        [HttpGet]
        public async Task<List<Book>> GetAllBook()
        {
            var result = await _bookService.GetAllBook();

            return result;
        }
        [HttpPost]
        public async Task<string> CreateUser(BookDTO model)
        {
            var result = await _bookService.Add(model);

            return result;
        }
    }
}
