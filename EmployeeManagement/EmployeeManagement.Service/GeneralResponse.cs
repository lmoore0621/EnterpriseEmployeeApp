using System.Collections.Generic;
using EmployeeManagement.DTOs;

namespace EmployeeManagement.Service
{
    public class GeneralResponse : Response
    {
        public IEnumerable<DegreeDto> DegreeOptions { get; set; }
        public IEnumerable<GenderDto> GenderOptions { get; set; }
        public IEnumerable<StateDto> StateOptions { get; set; }
    }
}
