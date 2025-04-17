using Microsoft.EntityFrameworkCore;
using PR3_Lab.Models;

namespace PR3_Lab.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        // Пример таблицы
        public DbSet<Job> Jobs { get; set; }
    }
}
