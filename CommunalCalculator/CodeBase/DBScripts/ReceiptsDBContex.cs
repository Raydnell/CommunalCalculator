using Microsoft.EntityFrameworkCore;
using CommunalCalculator.CodeBase.DBScripts.Models;

namespace CommunalCalculator.CodeBase.DBScripts
{
    public class ReceiptsDBContex : DbContext
    {
        public DbSet<Receipt> Receipts => Set<Receipt>();

        public ReceiptsDBContex()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)   
        {
            optionsBuilder.UseSqlite("Data Source=Receipts.db");
        }
    }
}
