using System;
using System.Collections.Generic;
using EmployeeManagement.Data;

namespace EmployeeManagement.Model.Services
{
    public class Service : IService
    {
        private IUnitOfWork baseUow;

        public Service(IUnitOfWork unitOfWork)
        {
            this.baseUow = unitOfWork;
        }

        public object GetUnitOfWorkInfo(string key)
        {
            return GetDataInfo(baseUow.UnitOfWorkInfo, key);
        }

        #region Helper Method

        protected object GetDataInfo(Dictionary<string, object> info, string key)
        {
            object value = null;

            if (info.ContainsKey(key))
            {
                value = info[key];
            }

            return value;
        }

        #endregion
    }
}
