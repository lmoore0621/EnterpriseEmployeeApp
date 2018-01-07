using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;

namespace EmployeeManagement.Data.Repositories
{
    public class Repository<TEntity, TEntityId> : IRepository<TEntity, TEntityId>
        where TEntity : BaseEntity<TEntityId>
        where TEntityId : struct
    {
        protected DataSource context;
        protected Dictionary<string, object> repoInfo;
        
        public Repository(DataSource context)
        {
            this.context = context;
            repoInfo = new Dictionary<string, object>();
        }

        public Dictionary<string, object> RepositoryInfo
        {
            get
            {
                return repoInfo;
            }
        }

        public void Add(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().AddRange(entities);
        }

        public void Add(TEntity entity)
        {
            context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            context.Set<TEntity>().Remove(entity);
        }

        public void Delete(IEnumerable<TEntityId> ids)
        {
            IEnumerable<TEntity> entities = Get(ids);
            Delete(entities);
        }

        public void Delete(IEnumerable<TEntity> entities)
        {
            context.Set<TEntity>().RemoveRange(entities);
        }

        public void Delete(TEntityId id)
        {
            TEntity entity = Get(id);
            Delete(entity);
        }

        public IEnumerable<TEntity> Get(IEnumerable<TEntityId> ids)
        {
            IEnumerable<TEntity> entities = context.Set<TEntity>().Where(e => ids.Contains(e.Id)).ToList();

            return entities;
        }

        public TEntity Get(TEntityId id)
        {
            TEntity entity = context.Set<TEntity>().Find(id);

            return entity;
        }

        public IEnumerable<TEntity> Get(Expression<Func<TEntity, object>> orderBy, int? skip = default(int?), int? take = default(int?))
        {
            ClearRepoInfo();

            int itemsFound = context.Set<TEntity>().Count();

            IEnumerable<TEntity> entities = new List<TEntity>();

            if (skip.HasValue && take.HasValue)
            {
                entities = context.Set<TEntity>().OrderBy(orderBy).Skip(skip.Value).Take(take.Value).ToList();
            }
            else if (skip.HasValue)
            {
                entities = context.Set<TEntity>().OrderBy(orderBy).Skip(skip.Value).ToList();
            }
            else if (take.HasValue)
            {
                entities = context.Set<TEntity>().OrderBy(orderBy).Take(take.Value).ToList();
            }
            else
            {
                entities = context.Set<TEntity>().OrderBy(orderBy).ToList();
            }

            SetRepoInfo("ItemsFound", itemsFound);

            return entities;
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate, Expression<Func<TEntity, object>> orderBy, int? skip = default(int?), int? take = default(int?))
        {
            ClearRepoInfo();

            int itemsFound = context.Set<TEntity>().Count(predicate);

            IEnumerable<TEntity> entities = new List<TEntity>();

            if (skip.HasValue && take.HasValue)
            {
                entities = context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip.Value).Take(take.Value).ToList();
            }
            else if (skip.HasValue)
            {
                entities = context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Skip(skip.Value).ToList();
            }
            else if (take.HasValue)
            {
                entities = context.Set<TEntity>().Where(predicate).OrderBy(orderBy).Take(take.Value).ToList();
            }
            else
            {
                entities = context.Set<TEntity>().Where(predicate).OrderBy(orderBy).ToList();
            }

            SetRepoInfo("ItemsFound", itemsFound);

            return entities;
        }

        public void Update(IEnumerable<TEntity> entities)
        {
            foreach(TEntity entity in entities)
            {
                Update(entity);
            }
        }

        public void Update(TEntity entity)
        {
            context.Entry(entity).State = EntityState.Modified;
        }
        
        #region Helper Methods

        protected void ClearRepoInfo()
        {
            RepositoryInfo.Clear();
        }

        protected void SetRepoInfo(string key, object value)
        {
            RepositoryInfo.Add(key, value);
        }

        #endregion
    }
}
