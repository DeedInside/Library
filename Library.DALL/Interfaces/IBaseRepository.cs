using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Library.DALL.Interfaces
{
    public interface IBaseRepository<T>
    {
        /// <summary>
        /// Добавить запись в БД
        /// </summary>
        /// <param name="value"></param>
        /// <returns> Id созданной записи</returns>
        Task<int> Add(T value);
        /// <summary>
        /// Удалить запись из БД
        /// </summary>
        /// <param name="value"></param>
        /// <returns>true в случае успеха</returns>
        Task<bool> Remove(int id);
    }
}
