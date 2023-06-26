using Library.Domain.Models;
using Library.Domain.Models.Dto;
using Library.Service.Interfasec;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BookController : Controller
    {
        private IBookService _bookService;

        public BookController(IBookService bookService)
        {
            _bookService = bookService;
        }

        /// <summary>
        /// добавить новую книгу
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpPost, Route("addBook")]
        public async Task<JsonResult> addBook(BookDto book)
        {
            var rezult = await _bookService.AddBook(book);
            return new JsonResult(rezult);
        }
        /// <summary>
        /// изменить данные о книге
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpPut, Route("changeBook")]
        public async Task<JsonResult> changeBook(Book book)
        {
            var rezult = await _bookService.ToChangeBook(book);
            return new JsonResult(rezult);
        }
        /// <summary>
        /// удалить данные о книге
        /// </summary>
        /// <param name="book"></param>
        /// <returns></returns>
        [HttpDelete, Route("removeBook")]
        public async Task<JsonResult> removeBook(int id)
        {
            var rezult = await _bookService.RemoveBook(id);
            return new JsonResult(rezult);
        }
        /// <summary>
        /// получить данные о книге по ID
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("bookId")]
        public async Task<JsonResult> bookId(int id)
        {
            var rezult = await _bookService.GetBookById(id);
            return new JsonResult(rezult);
        }
        /// <summary>
        /// получить список доступных книг
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("avalibleBook")]
        public async Task<JsonResult> avalibleBook()
        {
            var rezult = await _bookService.ListAvailableBooksk();
            return new JsonResult(rezult);
        }
        /// <summary>
        /// получить список выданных книг
        /// </summary>
        /// <returns></returns>
        [HttpGet, Route("issuedBook")]
        public async Task<JsonResult> issuedBook()
        {
            var rezult = await _bookService.ListIssuedBook();
            return new JsonResult(rezult);
        }
        /// <summary>
        /// получить список доступных для выдачи книг
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        [HttpGet, Route("bookName")]
        public async Task<JsonResult> bookName(string name)
        {
            var rezult = await _bookService.GetBookByName(name);
            return new JsonResult(rezult);
        }
    }
}
