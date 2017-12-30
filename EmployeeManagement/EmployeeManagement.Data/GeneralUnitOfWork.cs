using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EmployeeManagement.Data.Repositories;

namespace EmployeeManagement.Data
{
    public class GeneralUnitOfWork : UnitOfWork, IGeneralUnitOfWork
    {
        public GeneralUnitOfWork(DataSource context)
            : base(context)
        {
            Degrees = new DegreeRepository(context);
            Genders = new GenderRepository(context);
            States = new StateRepository(context);
        }

        public IDegreeRepository Degrees { get; set; }

        public IGenderRepository Genders { get; set; }

        public IStateRepository States { get; set; }
    }
}
