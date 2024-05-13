using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using BS.Domain.MenuAggregates;

using Microsoft.EntityFrameworkCore;

namespace BS.Infrastructure.Persistence
{
    public class BSDbContext : DbContext
    {
        public BSDbContext(DbContextOptions<BSDbContext> options) : base(options)
        {

        }

        public DbSet<Menu> Menus { get; set; } = null;
    }
}
