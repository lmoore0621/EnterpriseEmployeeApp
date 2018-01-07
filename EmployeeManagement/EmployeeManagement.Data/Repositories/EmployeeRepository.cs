using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Data.Entity;
using EmployeeManagement.Model;

namespace EmployeeManagement.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(DataSource context)
            : base(context)
        {

        }

        public IEnumerable<Employee> GetWithRelatedData(Expression<Func<Employee, object>> orderBy, int? skip = default(int?), int? take = default(int?))
        {
            ClearRepoInfo();

            int itemsFound = context.Set<Employee>().Count();

            IEnumerable<Employee> entities = new List<Employee>();

            if (skip.HasValue && take.HasValue)
            {
                entities = context.Employees.Include(e => e.Degree).Include(e => e.State).Include(e => e.Gender)
                    .OrderBy(orderBy).Skip(skip.Value).Take(take.Value).ToList();
            }
            else if (skip.HasValue)
            {
                entities = context.Set<Employee>().Include(e => e.Degree).Include(e => e.State).Include(e => e.Gender)
                    .OrderBy(orderBy).Skip(skip.Value).ToList();
            }
            else if (take.HasValue)
            {
                entities = context.Set<Employee>().Include(e => e.Degree).Include(e => e.State).Include(e => e.Gender)
                    .OrderBy(orderBy).Take(take.Value).ToList();
            }
            else
            {
                entities = context.Set<Employee>().Include(e => e.Degree).Include(e => e.State).Include(e => e.Gender)
                    .OrderBy(orderBy).ToList();
            }

            SetRepoInfo("ItemsFound", itemsFound);

            return entities;
        }
    }
}
