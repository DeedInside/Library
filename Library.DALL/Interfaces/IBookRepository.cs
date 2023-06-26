using Library.Domain.Models;
using Library.Domain.Models.Dto;

namespace Library.DALL.Interfaces
{
    public interface IBookRepository: IBaseRepository<BookDto>
    {
        /// <summary>
        /// Получить книгу по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>class Book</returns>
        Task<BookDto> GetBook(int id);
        /// <summary>
        /// получить список выданных книг
        /// </summary>
        /// <returns>List<Book></returns>
        Task<List<AvailableBooks>> ListIssuedBook();
        /// <summary>
        /// получить список доступных для выдачи книг
        /// </summary>
        /// <returns>List<Book></returns>
        Task<List<Book>> ListAvailableBooksk();
        /// <summary>
        /// поиск книг(и) по наименованию(части наименования)
        /// </summary>
        /// <param name="name"></param>
        /// <returns>class Book</returns>
        Task<List<Book>> GetBook(string name);
        /// <summary>
        /// Изменить запись в ДБ
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true в случае успеха</returns>
        Task<bool> ToChange(Book value);

    }
}
