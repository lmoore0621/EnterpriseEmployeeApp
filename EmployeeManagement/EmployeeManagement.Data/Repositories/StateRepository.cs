using EmployeeManagement.Model;

namespace EmployeeManagement.Data.Repositories
{
    public class StateRepository : Repository<State, int>, IStateRepository
    {
        public StateRepository(DataSource context)
            : base(context)
        {

        }
    }
}