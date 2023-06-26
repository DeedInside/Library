using Library.DALL.Interfaces;
using Library.Domain.Models;
using Library.Service.Interfasec;
using System.Reflection.PortableExecutable;

namespace Library.Service.Implementations
{
    public class ReaderService : IReaderService
    {
        private IReaderRepository _readerRepository;

        public ReaderService(IReaderRepository readerRepository)
        {
            _readerRepository = readerRepository;
        }

        public async Task<Answer<int>> AddReader(Reader value)
        {
            var answer = new Answer<int>();

            if(value != null)
            {
                int IdReader = await _readerRepository.Add(value);
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

        public async Task<Answer<Reader>> GetBookReaderById(int Id)
        {
            var answer = new Answer<Reader>();

            if (!Equals(Id))
            {
                var reader = await _readerRepository.BookReader(Id);
                answer.Message = "successfully";
                answer.Value = reader;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<List<Reader>>> FindReaderByFIO(string FIO)
        {
            var answer = new Answer<List<Reader>>();

            if (FIO != null)
            {
                var reader = await _readerRepository.FindReader(FIO);
                answer.Message = "successfully";
                answer.Value = reader;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<bool>> IssueBook(int IdBook, int IdReader)
        {
            var answer = new Answer<bool>();

            if (!Equals(IdBook) && !Equals(IdReader))
            {
                bool reader  = await _readerRepository.IssueBook(IdBook, IdReader);
                answer.Message = "successfully";
                answer.Value = reader;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<bool>> RemoveReader(int id)
        {
            var answer = new Answer<bool>();

            if (!Equals(id))
            {
                bool reader = await _readerRepository.Remove(id);
                answer.Message = "successfully";
                answer.Value = reader;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<bool>> ToChangeReader(Reader value)
        {
            var answer = new Answer<bool>();

            if (value != null)
            {
                bool reader = await _readerRepository.ToChange(value);
                answer.Message = "successfully";
                answer.Value = reader;
                return answer;
            }
            else
            {
                answer.Message = "error";
                return answer;
            }
        }

        public async Task<Answer<bool>> WriteOutBook(int Id)
        {
            var answer = new Answer<bool>();

            if (Equals(Id))
            {
                bool reader = await _readerRepository.WriteOutBook(Id);
                answer.Message = "successfully";
                answer.Value = reader;
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
