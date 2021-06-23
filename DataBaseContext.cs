using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleTest.Models;
using Microsoft.EntityFrameworkCore;

namespace ConsoleTest
{
    //контекст базы данных
    public class DataBaseContext:DbContext
    {
        public DbSet<Word> Words { get; set; }
        public DataBaseContext()
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(@"Server=(localdb)\mssqllocaldb;Database=ConsoleTest;Trusted_Connection=True;");
        }
    }
}
