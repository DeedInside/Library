using Library.DALL.Interfaces;
using Library.Domain.Models;
using Library.Domain.Models.Dto;
using Microsoft.EntityFrameworkCore;
using System.Xml.Linq;

namespace Library.DALL.Repositories
{
    public class BookRepository : IBookRepository
    {
        public async Task<int> Add(BookDto value)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    Book newsBook = new(value.Name,value.Autor,value.Arc,value.AgePublic,value.CounBook);
                    var rezult = await db.DbBooks.AddAsync(newsBook);
                    await db.SaveChangesAsync();
                    return rezult.Entity.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<BookDto> GetBook(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var request = await db.DbBooks.FirstOrDefaultAsync(Q => Q.Id == id);
                    if (request != null)
                    {
                        BookDto retzult = new(
                            request.Name,
                            request.Autor,
                            request.Arc,
                            request.AgePublic,
                            request.CounBook);
                        
                        return retzult;
                    }
                    else
                    {
                        throw new Exception($"Could not find book {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Book>> GetBook(string name)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var fund = await db.DbBooks.Where(p => p.Name == name).ToListAsync();
                    if (fund != null)
                    {
                        
                        return fund;
                    }
                    else
                    {
                        throw new Exception($"Could not find book");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Book>> ListAvailableBooksk()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var fund = await db.DbBooks.Where(p => p.CounBook > 0).ToListAsync();
                    if (fund != null)
                    {
                        return fund;
                    }
                    else
                    {
                        throw new Exception($"Could not find book");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<AvailableBooks>> ListIssuedBook()
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var request = await db.DbAvailableBooks.ToListAsync();
                    if (request != null)
                    {
                        return request;
                    }
                    else
                    {
                        throw new Exception($"Could not find book");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> Remove(int id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var rezult = await db.DbBooks.FirstOrDefaultAsync(q => q.Id == id);
                    if (rezult != null)
                    {
                        db.DbBooks.Remove(rezult);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Could not find book {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ToChange(Book value)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var rezult = await db.DbBooks.FirstOrDefaultAsync(q => q.Id == value.Id);
                    if (rezult != null)
                    {
                        rezult.Autor = value.Autor;
                        rezult.Arc = value.Arc;
                        rezult.AgePublic = value.AgePublic;
                        rezult.CounBook = value.CounBook;

                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Could not find book {value.Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }
    }
}
