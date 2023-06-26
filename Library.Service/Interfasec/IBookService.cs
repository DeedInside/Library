
using Library.Domain.Models;
using Library.Domain.Models.Dto;

namespace Library.Service.Interfasec
{
    public interface IBookService
    {
        /// <summary>
        /// Добавить книгу
        /// </summary>
        /// <param name="value"></param>
        /// <returns> Id созданной записи</returns>
        Task<Answer<int>> AddBook(BookDto value);
        /// <summary>
        /// Изменить запись о книге
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true в случае успеха</returns>
        Task<Answer<bool>> ToChangeBook(Book value);
        /// <summary>
        /// Удалить запись о книге
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true в случае успеха</returns>
        Task<Answer<bool>> RemoveBook(int id);
        /// <summary>
        /// Получить книгу по id
        /// </summary>
        /// <param name="id"></param>
        /// <returns>class Book</returns>
        Task<Answer<BookDto>> GetBookById(int id);
        /// <summary>
        /// получить список выданных книг
        /// </summary>
        /// <returns>List<Book></returns>
        Task<Answer<List<AvailableBooks>>> ListIssuedBook();
        /// <summary>
        /// получить список доступных для выдачи книг
        /// </summary>
        /// <returns>List<Book></returns>
        Task<Answer<List<Book>>> ListAvailableBooksk();
        /// <summary>
        /// поиск книг(и) по наименованию(части наименования)
        /// </summary>
        /// <param name="name"></param>
        /// <returns>class Book</returns>
        Task<Answer<List<Book>>> GetBookByName(string name);
    }
}
