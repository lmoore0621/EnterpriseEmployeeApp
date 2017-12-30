using EmployeeManagement.Data.Repositories;

namespace EmployeeManagement.Data
{
    public class EmployeeUnitOfWork : UnitOfWork, IEmployeeUnitOfWork
    {
        public EmployeeUnitOfWork(DataSource context)
            : base(context)
        {
            Employees = new EmployeeRepository(context);
        }

        public IEmployeeRepository Employees { get; set; }
    }
}
