using EmployeeManagement.Data.Repositories;

namespace EmployeeManagement.Data
{
    public interface IEmployeeUnitOfWork : IUnitOfWork
    {
        IEmployeeRepository Employees { get; set; }
    }
}
