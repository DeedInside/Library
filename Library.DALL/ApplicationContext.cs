using Library.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace Library.DALL
{
    public class ApplicationContext : DbContext
    {
        public DbSet<Book> DbBooks { get; set; }
        public DbSet<Reader> DbReader { get; set; }
        public DbSet<AvailableBooks> DbAvailableBooks { get; set; }

        public ApplicationContext()
        {
            Database.EnsureCreated();
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseNpgsql("Host=localhost;Port=5432;Database=Library;Username=postgres;Password=123");
        }
    }
}
