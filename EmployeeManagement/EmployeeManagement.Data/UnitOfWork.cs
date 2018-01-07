using System;
using System.Collections.Generic;
using System.Data.Entity;

namespace EmployeeManagement.Data
{
    public class UnitOfWork : IUnitOfWork
    {
        protected DataSource context;
        protected Dictionary<string, object> uowInfo;

        public UnitOfWork(DataSource context)
        {
            this.context = context;
            this.context.Configuration.LazyLoadingEnabled = false;
            uowInfo = new Dictionary<string, object>();
        }

        public Dictionary<string, object> UnitOfWorkInfo
        {
            get
            {
                return uowInfo;
            }
        }

        public int Commit()
        {
            return context.SaveChanges();
        }
    }
}
