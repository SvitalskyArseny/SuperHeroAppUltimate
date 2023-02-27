using Microsoft.EntityFrameworkCore;
using SuperHeroProject.domain.model;
using SuperHeroProject.domain.model.user;

namespace SuperHeroProject.infrastructure.db
{
    public class AppDatabase : DbContext
    {
        public DbSet<User> User { get; set; } = null!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Data Source=superheroapp.db");
        }
    }
}