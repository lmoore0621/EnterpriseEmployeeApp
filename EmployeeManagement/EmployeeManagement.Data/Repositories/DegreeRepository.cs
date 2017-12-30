using EmployeeManagement.Model;

namespace EmployeeManagement.Data.Repositories
{
    public class DegreeRepository : Repository<Degree, int>, IDegreeRepository
    {
        public DegreeRepository(DataSource context)
            : base(context)
        {

        }
    }
}
