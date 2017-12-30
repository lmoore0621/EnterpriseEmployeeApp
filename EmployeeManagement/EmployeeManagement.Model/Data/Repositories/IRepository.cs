using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeeManagement.Data.Repositories
{
    public interface IRepository<TEntity, TEntityId>
        where TEntity : BaseEntity<TEntityId>
        where TEntityId : struct
    {
        void Add(TEntity entity);

        void Add(IEnumerable<TEntity> entities);

        IEnumerable<TEntity> Get(int? skip = null, int? take = null);

        TEntity Get(TEntityId id);

        IEnumerable<TEntity> Search(Expression<Func<TEntity, bool>> predicate, int? skip = null, int? take = null);

        void Update(TEntity entity);

        void Update(IEnumerable<TEntity> entities);

        void Delete(TEntityId id);

        void Delete(IEnumerable<TEntityId> ids);

        void Delete(TEntity entity);

        void Delete(IEnumerable<TEntity> entities);

        Dictionary<string, object> RepositoryInfo { get; }
    }
}
