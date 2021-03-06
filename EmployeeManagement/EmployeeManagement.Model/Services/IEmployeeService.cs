﻿using System;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace EmployeeManagement.Model.Services
{
    public interface IEmployeeService : IService
    {
        IEnumerable<Employee> GetAllEmployees(Expression<Func<Employee, object>> orderBy, int? skip = null, int? take = null);

        IEnumerable<Employee> SearchEmployees(Expression<Func<Employee, bool>> predicate, Expression<Func<Employee, object>> orderBy, int? skip = null, int? take = null);

        Employee GetEmployee(int employeeId);

        void CreateEmployee(Employee employee);

        void UpdateEmployee(Employee employee);

        void DeleteEmployee(int employeeId);

        int EmployeesFound { get; }
    }
}
