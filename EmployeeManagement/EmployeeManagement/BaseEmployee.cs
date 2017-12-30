﻿using System;

namespace EmployeeManagement
{
    public class BaseEmployee : BaseEntity
    {
        public int DegreeId { get; set; }

        public int StateId { get; set; }

        public int GenderId { get; set; }

        public string Name { get; set; }

        public DateTime BirthDate { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }
    }
}
