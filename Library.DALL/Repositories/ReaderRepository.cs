using Library.DALL.Interfaces;
using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Runtime.CompilerServices;
using System.Xml.Linq;

namespace Library.DALL.Repositories
{
    public class ReaderRepository : IReaderRepository
    {
        public async Task<int> Add(Reader value)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var rezult = await db.DbReader.AddAsync(value);
                    await db.SaveChangesAsync();
                    return rezult.Entity.Id;
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<Reader> BookReader(int Id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var rezult = await db.DbReader.FirstOrDefaultAsync(Q => Q.Id == Id);
                    if(rezult != null)
                    {
                        return rezult;
                    }
                    else
                    {
                        throw new Exception($"Could not find reader {Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<List<Reader>> FindReader(string FIO)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var ListFIO = FIO.Split(" ").ToList();

                    var request = await db.DbReader.Where(p => p.Name == ListFIO[1] || p.Family == ListFIO[0] || p.Patronymic == ListFIO[2]).ToListAsync(); ;
                    if(request != null)
                    {
                        return request;
                    }
                    else
                    {
                        throw new Exception($"Could not find reader {FIO}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> IssueBook(int IdBook, int IdReader)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var rezult = await db.DbBooks.FirstOrDefaultAsync(q => q.Id == IdBook);
                    if(rezult != null && rezult.CounBook > 0)
                    {
                        var request = await db.DbAvailableBooks.FirstOrDefaultAsync(q => q.IdBook == rezult.Id);
                        if(request == null)
                        {
                            AvailableBooks availableBooks = new(rezult.Id,new List<int>() { IdReader });
                            db.DbAvailableBooks.Add(availableBooks);

                        }
                        else
                        {
                            request.IdReader.Add(IdReader);
                        }
                        rezult.CounBook -= 1;
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Could not find reader {IdBook}");
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
                    var rezult = await db.DbReader.FirstOrDefaultAsync(q => q.Id == id);
                    if(rezult != null)
                    {
                        db.DbReader.Remove(rezult);
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Could not find reader {id}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> ToChange(Reader value)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var rezult = await db.DbReader.FirstOrDefaultAsync(q => q.Id == value.Id);
                    if (rezult != null)
                    {
                        rezult.Family = value.Family;
                        rezult.Name = value.Name;
                        rezult.Patronymic = value.Patronymic;
                        rezult.YearBirth = value.YearBirth;
                        
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Could not find reader {value.Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                throw new Exception(ex.Message);
            }
        }

        public async Task<bool> WriteOutBook(int Id)
        {
            try
            {
                using (ApplicationContext db = new ApplicationContext())
                {
                    var rezult = await db.DbBooks.FirstOrDefaultAsync(q => q.Id == Id);
                    if (rezult != null)
                    {
                        rezult.CounBook += 1;
                        await db.SaveChangesAsync();
                        return true;
                    }
                    else
                    {
                        throw new Exception($"Could not find reader {Id}");
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
