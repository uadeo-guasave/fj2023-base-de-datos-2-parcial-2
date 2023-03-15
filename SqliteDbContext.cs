using EfOrmNet.Models;
using Microsoft.EntityFrameworkCore;

namespace EfOrmNet;

class SqliteDbContext : DbContext
{
    public DbSet<Editorial> Editoriales { get; set; }
    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseSqlite("Data Source=Db/biblioteca.db");
        base.OnConfiguring(optionsBuilder);
    }
}