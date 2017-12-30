using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeeManagement.Model.Services
{
    public interface IEmployeeService : IService
    {
        IEnumerable<Employee> GetAllEmployees(int? skip = null, int? take = null);

        IEnumerable<Employee> SearchEmployees(Expression<Func<Employee, bool>> predicate, int? skip = null, int? take = null);

        void CreateEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(int employeeId);
    }
}
