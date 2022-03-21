using DictionaryApp.Database.Models;
using Microsoft.EntityFrameworkCore;

namespace DictionaryApp.Database
{
    public class AppDbContext : DbContext
    {
        public DbSet<DictionaryEntry> DictionaryEntries { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=(localdb)\mssqllocaldb;Database=DictionaryDB;Trusted_Connection=True");
        }
    }
}
