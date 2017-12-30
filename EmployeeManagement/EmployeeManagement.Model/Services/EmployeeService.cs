using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using EmployeeManagement.Data;

namespace EmployeeManagement.Model.Services
{
    public class EmployeeService : Service, IEmployeeService
    {
        private IEmployeeUnitOfWork unitOfWork;

        public EmployeeService(IEmployeeUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public void CreateEmployee(Employee employee)
        {
            unitOfWork.Employees.Add(employee);
            unitOfWork.Commit();
        }

        public void DeleteEmployee(int employeeId)
        {
            unitOfWork.Employees.Delete(employeeId);
            unitOfWork.Commit();
        }

        public IEnumerable<Employee> GetAllEmployees(int? skip = default(int?), int? take = default(int?))
        {
            IEnumerable<Employee> employees = unitOfWork.Employees.Get(skip, take);

            return employees;
        }

        public IEnumerable<Employee> SearchEmployees(Expression<Func<Employee, bool>> predicate, int? skip = default(int?), int? take = default(int?))
        {
            IEnumerable<Employee> employees = unitOfWork.Employees.Search(predicate, skip, take);

            return employees;
        }

        public void UpdateEmployee(Employee employee)
        {
            unitOfWork.Employees.Update(employee);
            unitOfWork.Commit();
        }
    }
}
