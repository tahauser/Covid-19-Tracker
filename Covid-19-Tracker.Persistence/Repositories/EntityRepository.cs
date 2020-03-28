using System;
using Covid_19_Tracker.Persistence.Repositories.interfaces;

namespace Covid_19_Tracker.Persistence.Repositories
{
    public class EntityRepository : IEntityRepository
    {
        private readonly AppDbContext _appDbContext;

        public EntityRepository(AppDbContext appDbContext)
        {
            _appDbContext = appDbContext;
        }
    }
}
