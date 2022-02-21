using Webmotors.Domain.Repositories;
using Webmotors.Infra.DBContext;

namespace Webmotors.Infra.Repositories
{
    public abstract class BaseRepository : IBaseRepository
    {
        protected DbContextWebmotors _dbContext;

        public BaseRepository(DbContextWebmotors dbContext)
        {
            _dbContext = dbContext;
        }

        public void SaveChanges()
        {
            _dbContext.SaveChanges();
        }
    }
}
