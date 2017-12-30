using EmployeeManagement.Model;

namespace EmployeeManagement.Data.Repositories
{
    public class GenderRepository : Repository<Gender, int>, IGenderRepository
    {
        public GenderRepository(DataSource context)
            : base(context)
        {

        }
    }
}