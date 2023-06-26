using Library.Domain.Models;

namespace Library.DALL.Interfaces
{
    public interface IReaderRepository: IBaseRepository<Reader>
    {
        /// <summary>
        /// выдать книгу читателю
        /// </summary>
        /// <param name="Id"> Id выдаваемой книги</param>
        /// <returns>true при успехе</returns>
        Task<bool> IssueBook(int IdBook, int IdReader);
        /// <summary>
        /// сдать книгу в библиотеку
        /// </summary>
        /// <param name="Id">Id сдаваемой книги</param>
        /// <returns>true при успехе</returns>
        Task<bool> WriteOutBook(int Id);
        /// <summary>
        /// получить данные о читателе по ID(по возможности со списком выданных книг)
        /// </summary>
        /// <param name="Id">Id книги</param>
        /// <returns>class Reader</returns>
        Task<Reader> BookReader(int Id);
        /// <summary>
        /// поиск читателя(-ей) по ФИО(части ФИО) (по возможности со списком выданных книг)
        /// </summary>
        /// <param name=""></param>
        /// <returns>calss Reader</returns>
        Task<List<Reader>> FindReader(string FIO);
        /// <summary>
        /// Изменить запись в ДБ
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true в случае успеха</returns>
        Task<bool> ToChange(Reader value);

    }
}
