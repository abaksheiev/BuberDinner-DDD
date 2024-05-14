using BS.Domain.Common.Models;
using BS.Domain.MenuAggregates;
using BS.Infrastructure.Persistence.Interceptors;

using Microsoft.EntityFrameworkCore;

namespace BS.Infrastructure.Persistence
{
    public class BSDbContext : DbContext
    {
        private readonly PublishDomainEventsInterceptor _publishDomainEventsInterceptor;
        public BSDbContext(DbContextOptions<BSDbContext> options, PublishDomainEventsInterceptor publishDomainEventsInterceptor) 
            : base(options)
        {
            _publishDomainEventsInterceptor = publishDomainEventsInterceptor;
        }

        public DbSet<Menu> Menus { get; set; } = null;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder
                .Ignore<List<IDomainEvent>>()
                .ApplyConfigurationsFromAssembly(typeof(BSDbContext).Assembly);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.AddInterceptors(_publishDomainEventsInterceptor);
            base.OnConfiguring(optionsBuilder);
        }
    }
}
