using BS.Domain.MenuAggregates;

using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;

namespace BS.Infrastructure.Persistence
{
    public class BSDbContext : DbContext
    {
        public BSDbContext(DbContextOptions<BSDbContext> options) : base(options)
        {
       
        }

        public DbSet<Menu> Menus { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(BSDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }
    }
}
