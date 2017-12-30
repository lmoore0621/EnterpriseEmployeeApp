using System;
using System.Collections.Generic;
using EmployeeManagement.Data;

namespace EmployeeManagement.Model.Services
{
    public class GeneralService : Service, IGeneralService
    {
        private IGeneralUnitOfWork unitOfWork;

        public GeneralService(IGeneralUnitOfWork unitOfWork)
            : base(unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }

        public IEnumerable<Degree> GetDegreeOptions()
        {
            IEnumerable<Degree> degrees = unitOfWork.Degrees.Get();
            return degrees;
        }

        public IEnumerable<Gender> GetGenderOptions()
        {
            IEnumerable<Gender> genders = unitOfWork.Genders.Get();
            return genders;
        }

        public IEnumerable<State> GetStateOptions()
        {
            IEnumerable<State> states = unitOfWork.States.Get();
            return states;
        }
    }
}
