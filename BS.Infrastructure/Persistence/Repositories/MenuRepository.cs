using BS.Application.Persistence;
using BS.Domain.MenuAggregates;

namespace BS.Infrastructure.Persistence.Repositories
{
    internal class MenuRepository : IMenuRepository
    {
        private readonly BSDbContext _dbContext;
        private readonly List<Menu> _menus = new();

        public MenuRepository(BSDbContext dbContext)
        {
            _dbContext = dbContext;
        }
        public void Add(Menu menu)
        {
            _dbContext.Menus.Add(menu);
            _dbContext.SaveChanges();
        } 
    }
}
