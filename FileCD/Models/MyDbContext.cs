using Microsoft.EntityFrameworkCore;

namespace FileCD.Models
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options):base(options) { }
        public DbSet<FileItems> fileItems { get; set; }
    }
}
