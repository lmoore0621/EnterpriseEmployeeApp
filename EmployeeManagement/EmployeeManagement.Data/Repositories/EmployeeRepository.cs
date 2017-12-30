using EmployeeManagement.Model;

namespace EmployeeManagement.Data.Repositories
{
    public class EmployeeRepository : Repository<Employee, int>, IEmployeeRepository
    {
        public EmployeeRepository(DataSource context)
            : base(context)
        {

        }
    }
}
