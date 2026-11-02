using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Termekek.Data
{
    public class TermekContext : DbContext
    {
        public DbSet<Models.Termek> Termekek { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
           optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDB;Database=TermekNyilvantartas;Trusted_Connection=True;");
        }
    }
}
