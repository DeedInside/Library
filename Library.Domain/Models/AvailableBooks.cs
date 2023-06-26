using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class AvailableBooks
    {
        public AvailableBooks(int idBook, List<int>? idReader)
        {
            IdBook = idBook;
            IdReader = idReader;
        }
        public AvailableBooks(int id, int idBook, List<int>? idReader)
        {
            this.id = id;
            IdBook = idBook;
            IdReader = idReader;
        }
        public int id { get; set; }
        public int IdBook { get; set; }
        public List<int>? IdReader { get; set; }
    }
}
