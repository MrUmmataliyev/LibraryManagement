using LibraryManagement.Application.Abstractions;
using LibraryManagement.Application.Abstractions.IService;
using LibraryManagement.Domain.Entities.DTOs;
using LibraryManagement.Domain.Entities.Models;

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
                await _bookRepository.Create(book);
                return "Added";
            }
            return "Failed";
        }

        public async Task<string> Delete(int id)
        {
            var result =await _bookRepository.Delete(x => x.ID == id);
            if (result)
            {
                return "Deleted";
            }
            else
            {
                return "Failed";
            }
           
        }

        public async Task<List<Book>> GetAllBook()
        {
            var result = await _bookRepository.GetAll();
            return result.ToList();
        }

        public async Task<List<Book>> GetByName(string name)
        {
            var result = await _bookRepository.GetAll();
            return result.Where(x=> x.BookName == name).ToList();
        }

        public async Task<List<Book>> GetByCategory(string Category)
        {
            var result = await _bookRepository.GetAll();
            return result.Where(x => x.Category == Category).ToList();
        }
        public async Task<List<Book>> GetByPublishedYear(int year)
        {
            var result = await _bookRepository.GetAll();
            return result.Where(x => x.PublishedYear == year).ToList();
        }
        public async Task<List<Book>> GetBySector(string sector)
        {
            var result = await _bookRepository.GetAll();
            return result.Where(x => x.BookShelfSector == sector).ToList();
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
        public async Task<List<Book>> GetByAuthor(string authorName)
        {
            var result = await _bookRepository.GetAll();
            return result.Where(x => x.AuthorName == authorName).ToList();
        }
        public async Task<string> Update(int id, BookDTO bookDTO)
        {
            var res = await _bookRepository.GetByAny(x=> x.ID == id);
            
            if(res != null)
            {


                res.BookName = bookDTO.BookName;
                res.AuthorName = bookDTO.AuthorName;
                res.BookShelfSector = bookDTO.BookShelfSector;
                res.Category = bookDTO.Category;
                res.PublishedYear = bookDTO.PublishedYear;
               

                var result = await _bookRepository.Update(res);
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
