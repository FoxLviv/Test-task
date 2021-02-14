using Microsoft.EntityFrameworkCore;
using DB.Entities;
using DB.Configurations;

namespace DB
{
    public class BODbContext : DbContext
    {
        public BODbContext(DbContextOptions<BODbContext> options) : base(options) { }

        public DbSet<BaseEntity> Bases { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(
                @"Server=desktop-8devsof;Database=BitsOrchestra;Integrated Security=True");//Data Source=desktop-8devsof;Initial Catalog=BitsOrchestra;Integrated Security=True;Pooling=False
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.ApplyConfiguration(new BaseConfiguration());
        }
    }
}
