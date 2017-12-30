using System;

namespace EmployeeManagement.Model
{
    public class Employee : BaseEmployee
    {

        public override int Age
        {
            get
            {
                return GetAge();
            }
        }

        public Gender Gender { get; set; }

        public Degree Degree { get; set; }

        public State State { get; set; }

        #region Helper Methods 

        private int GetAge()
        {
            TimeSpan ts = DateTime.Now - BirthDate;

            return ts.Days / 365;
        }

        #endregion
    }
}
