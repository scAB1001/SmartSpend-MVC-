using Microsoft.EntityFrameworkCore;
namespace SmartSpend.Models
{
    public class SmartSpendDbContext : DbContext
    {
        public SmartSpendDbContext(DbContextOptions<SmartSpendDbContext> options) 
            : base(options)
        {
        }
        public DbSet<Expense> Expenses { get; set; }
    }
}
