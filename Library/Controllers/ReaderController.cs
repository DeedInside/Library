using Library.Domain.Models;
using Library.Service.Implementations;
using Library.Service.Interfasec;
using Microsoft.AspNetCore.Mvc;

namespace Library.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ReaderController : Controller
    {
        private IReaderService _readerService;

        public ReaderController(IReaderService readerService)
        {
            _readerService = readerService;
        }
        /// <summary>
        /// добавить нового читателя
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        [HttpPost, Route("addReader")]
        public async Task<JsonResult> addReader(Reader reader)
        {
            var rezult = await _readerService.AddReader(reader);
            return new JsonResult(rezult);
            
        }
        /// <summary>
        /// изменить данные о читателе
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        [HttpPut, Route("changeReader")]
        public async Task<JsonResult> changeReader(Reader reader)
        {
            var rezult = await _readerService.ToChangeReader(reader);
            return new JsonResult(rezult);
        }
        /// <summary>
        /// удалить данные о читателе
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        [HttpDelete, Route("removeReader")]
        public async Task<JsonResult> removeReader(int id)
        {
            var rezult = await _readerService.RemoveReader(id);
            return new JsonResult(rezult);
        }
        /// <summary>
        /// выдать книгу читателю
        /// </summary>
        /// <param name="IdBook"></param>
        /// <param name="IdReader"></param>
        /// <returns></returns>
        [HttpGet, Route("IssueBook")]
        public async Task<JsonResult> IssueBook(int IdBook,int IdReader)
        {
            var rezult = await _readerService.IssueBook(IdBook, IdReader);
            return new JsonResult(rezult);
        }
        /// <summary>
        /// получить данные о читателе по ID (по возможности со списком выданных книг)
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        [HttpGet, Route("readerId")]
        public async Task<JsonResult> readerId(int id)
        {
            var rezult = await _readerService.GetBookReaderById(id);
            return new JsonResult(rezult);
        }
        /// <summary>
        /// поиск читателя(-ей) по ФИО (части ФИО) (по возможности со списком выданных книг)
        /// </summary>
        /// <param name="FIO"></param>
        /// <returns></returns>
        [HttpGet, Route("readerFIO")]
        public async Task<JsonResult> readerFIO(string FIO)
        {
            var rezult = await _readerService.FindReaderByFIO(FIO);
            return new JsonResult(rezult);
        }
    }
}
