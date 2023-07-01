using System;
using System.Linq.Expressions;
using ImageStreaming.Shared.Persistence.Common;
using ImageStreaming.Shared.Persistence.Common.Interfaces.Repositories;
using ImageStreaming.Shared.Persistence.Entities;
using Microsoft.EntityFrameworkCore;

namespace ImageStreaming.Shared.Persistence.Repositories
{
	public class BaseRepository<TEntity> : IBaseRepository<TEntity>
		where TEntity : BaseEntity
	{
        protected readonly BaseDbContext _dbContext;

        protected DbSet<TEntity> DbSet => _dbContext.Set<TEntity>();

        public BaseRepository(BaseDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public virtual IQueryable<TEntity> GetQueryable(bool disableTracking = true)
        {
            IQueryable<TEntity> queryable = DbSet;
            if (disableTracking)
            {
                queryable = queryable.AsNoTracking();
            }
            queryable = SetDefaultOrderBy(queryable);

            return queryable;
        }

        public IQueryable<TEntity> GetQueryable(Expression<Func<TEntity, bool>> predicate)
        {
            IQueryable<TEntity> queryable = GetQueryable();
            if (predicate != null)
            {
                queryable = queryable.Where(predicate);
            }

            return queryable;
        }

        protected virtual Func<IQueryable<TEntity>, IOrderedQueryable<TEntity>>? GetOrderByDefault()
        {
            return null;
        }

        protected virtual IQueryable<TEntity> SetDefaultOrderBy(IQueryable<TEntity> queryable)
        {
            var defaultOrderBy = GetOrderByDefault();
            if (defaultOrderBy != null)
            {
                queryable = defaultOrderBy(queryable);
            }

            return queryable;
        }
    }
}

