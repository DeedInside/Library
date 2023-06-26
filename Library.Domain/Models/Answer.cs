using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.Domain.Models
{
    public class Answer<T>
    {
        private string? message;
        public T? Value {get; set;}

        public string Message
        {
            get
            {
                if (message == null || message == "")
                {
                    return "not description";
                }
                else
                {
                    return message;
                }
            }
            set
            {
                message = value;
            }
        }
    }
}
