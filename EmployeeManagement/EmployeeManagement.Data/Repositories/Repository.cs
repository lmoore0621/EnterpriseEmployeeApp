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

        public IEnumerable<TEntity> Get(int? skip = default(int?), int? take = default(int?))
        {
            ClearRepoInfo();

            int itemsFound = context.Set<TEntity>().Count();

            IEnumerable<TEntity> entities = new List<TEntity>();

            if (skip.HasValue && take.HasValue)
            {
                entities = context.Set<TEntity>().Skip(skip.Value).Take(take.Value).ToList();
            }
            else if (skip.HasValue)
            {
                entities = context.Set<TEntity>().Skip(skip.Value).ToList();
            }
            else if (take.HasValue)
            {
                entities = context.Set<TEntity>().Take(take.Value).ToList();
            }
            else
            {
                entities = context.Set<TEntity>().ToList();
            }

            SetRepoInfo("ItemsFound", itemsFound);

            return entities;
        }

        public IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate, int? skip = default(int?), int? take = default(int?))
        {
            ClearRepoInfo();

            int itemsFound = context.Set<TEntity>().Count(predicate);

            IEnumerable<TEntity> entities = new List<TEntity>();

            if (skip.HasValue && take.HasValue)
            {
                entities = context.Set<TEntity>().Where(predicate).Skip(skip.Value).Take(take.Value).ToList();
            }
            else if (skip.HasValue)
            {
                entities = context.Set<TEntity>().Where(predicate).Skip(skip.Value).ToList();
            }
            else if (take.HasValue)
            {
                entities = context.Set<TEntity>().Where(predicate).Take(take.Value).ToList();
            }
            else
            {
                entities = context.Set<TEntity>().Where(predicate).ToList();
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
            TEntity entityToUpdate = Get(entity.Id);

            context.Entry(entityToUpdate).OriginalValues.SetValues(entity);
        }
        
        #region Helper Methods

        protected void ClearRepoInfo()
        {
            RepositoryInfo.Clear();
        }

        protected void SetRepoInfo(string key, object value)
        {
            string repoName = GetType().Name;

            RepositoryInfo.Add(repoName + "-" + key, value);
        }

        #endregion
    }
}
