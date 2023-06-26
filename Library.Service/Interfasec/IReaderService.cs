using Library.Domain.Models;

namespace Library.Service.Interfasec
{
    public interface IReaderService
    {
        /// <summary>
        /// Добавить запись о читателе
        /// </summary>
        /// <param name="value"></param>
        /// <returns> Id созданной записи</returns>
        Task<Answer<int>> AddReader(Reader value);
        /// <summary>
        /// Изменить запись о читателе
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true в случае успеха</returns>
        Task<Answer<bool>> ToChangeReader(Reader value);
        /// <summary>
        /// Удалить запись о читателе
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true в случае успеха</returns>
        Task<Answer<bool>> RemoveReader(int id);
        /// <summary>
        /// выдать книгу читателю
        /// </summary>
        /// <param name="Id"> Id выдаваемой книги</param>
        /// <returns>true при успехе</returns>
        Task<Answer<bool>> IssueBook(int IdBook, int IdReader);
        /// <summary>
        /// сдать книгу в библиотеку
        /// </summary>
        /// <param name="Id">Id сдаваемой книги</param>
        /// <returns>true при успехе</returns>
        Task<Answer<bool>> WriteOutBook(int Id);
        /// <summary>
        /// получить данные о читателе по ID(по возможности со списком выданных книг)
        /// </summary>
        /// <param name="Id">Id книги</param>
        /// <returns>class Reader</returns>
        Task<Answer<Reader>> GetBookReaderById(int Id);
        /// <summary>
        /// поиск читателя(-ей) по ФИО(части ФИО) (по возможности со списком выданных книг)
        /// </summary>
        /// <param name=""></param>
        /// <returns>calss Reader</returns>
        Task<Answer<List<Reader>>> FindReaderByFIO(string FIO);
    }
}
