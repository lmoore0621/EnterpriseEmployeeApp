using System.Collections.Generic;

namespace EmployeeManagement.Data
{
    public interface IUnitOfWork
    {
        Dictionary<string, object> UnitOfWorkInfo { get; }

        int Commit();
    }
}
