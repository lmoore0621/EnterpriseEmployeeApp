using EmployeeManagement.Data.Repositories;

namespace EmployeeManagement.Data
{
    public interface IGeneralUnitOfWork : IUnitOfWork
    {
        IGenderRepository Genders { get; set; }

        IDegreeRepository Degrees { get; set; }

        IStateRepository States { get; set; }
    }
}
