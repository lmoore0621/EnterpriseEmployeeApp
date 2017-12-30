using System.Collections.Generic;

namespace EmployeeManagement.Model.Services
{
    public interface IGeneralService : IService
    {
        IEnumerable<State> GetStateOptions();

        IEnumerable<Degree> GetDegreeOptions();

        IEnumerable<Gender> GetGenderOptions();
    }
}
