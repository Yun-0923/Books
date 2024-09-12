using Microsoft.EntityFrameworkCore;

namespace Homework.Models
{
    public class dbGuestBookContext : DbContext
    {
        public dbGuestBookContext(DbContextOptions<dbGuestBookContext> options)
      : base(options)
        {
        }

        public virtual DbSet<Book> Book { get; set; }
        public virtual DbSet<ReBook> ReBook { get; set; }
        public virtual DbSet<Login> Login { get; set; }
    }
}
