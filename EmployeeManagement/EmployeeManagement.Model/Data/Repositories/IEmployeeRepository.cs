using EmployeeManagement.Model;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeeManagement.Data.Repositories
{
    public interface IEmployeeRepository : IRepository<Employee, int>
    {
        IEnumerable<Employee> GetWithRelatedData(Expression<Func<Employee, object>> orderBy, int? skip = default(int?), int? take = default(int?));
    }
}
