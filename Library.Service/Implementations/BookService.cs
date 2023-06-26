using Library.DALL.Interfaces;
using Library.Domain.Models;
using Library.Domain.Models.Dto;
using Library.Service.Interfasec;
using System.Xml.Linq;

namespace Library.Service.Implementations
{
    public class BookService : IBookService
    {
        private IBookRepository _bookRepository;

        public BookService(IBookRepository bookRepository)
        {
            _bookRepository = bookRepository;
        }

        public async Task<Answer<int>> AddBook(BookDto value)
        {
            var answer = new Answer<int>();

            if (value != null)
            {
                int IdReader = await _bookRepository.Add(value);
                answer.Message = "successfully";
                answer.Value = IdReader;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<BookDto>> GetBookById(int id)
        {
            var answer = new Answer<BookDto>();

            if (!Equals(id))
            {
                var book = await _bookRepository.GetBook(id);
                if(book != null)
                {
                    answer.Message = "successfully";
                    answer.Value = book;
                    return answer;
                }
                else
                {
                    answer.Message = "error";
                    return answer;
                }
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<List<Book>>> GetBookByName(string name)
        {
            var answer = new Answer<List<Book>>();

            if (name != null)
            {
                var book = await _bookRepository.GetBook(name);
                if(book != null)
                {
                    answer.Message = "successfully";
                    answer.Value = book;
                    return answer;
                }
                else
                {
                    answer.Message = "error";
                    return answer;
                }
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<List<Book>>> ListAvailableBooksk()
        {
            var answer = new Answer<List<Book>>();

            var book = await _bookRepository.ListAvailableBooksk();
            if (book.Count > 0)
            {
                answer.Message = "successfully";
                answer.Value = book;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }

        }

        public async Task<Answer<List<AvailableBooks>>> ListIssuedBook()
        {
            var answer = new Answer<List<AvailableBooks>>();

            var book = await _bookRepository.ListIssuedBook();

            if (book.Count > 0)
            {
                answer.Message = "successfully";
                answer.Value = book;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<bool>> RemoveBook(int id)
        {
            var answer = new Answer<bool>();

            if (!Equals(id))
            {
                var book = await _bookRepository.Remove(id);
                answer.Message = "successfully";
                answer.Value = book;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<bool>> ToChangeBook(Book value)
        {
            var answer = new Answer<bool>();

            if (value != null)
            {
                var book = await _bookRepository.ToChange(value);
                answer.Message = "successfully";
                answer.Value = book;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }
    }
}
