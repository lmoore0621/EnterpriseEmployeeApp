using EmployeeManagement.DTOs;
using EmployeeManagement.Model;
using AutoMapper;

namespace EmployeeManagement.Service
{
    public static class DtoMapper
    {
        public static void ConfigureMappings()
        {
            Mapper.Initialize(cfg =>
            {
                cfg.CreateMap<Employee, EmployeeDto>().PreserveReferences();
                cfg.CreateMap<EmployeeDto, Employee>().PreserveReferences();


                cfg.CreateMap<Gender, GenderDto>().PreserveReferences();
                cfg.CreateMap<GenderDto, Gender>().PreserveReferences();


                cfg.CreateMap<Degree, DegreeDto>().PreserveReferences();
                cfg.CreateMap<DegreeDto, Degree>().PreserveReferences();


                cfg.CreateMap<State, StateDto>().PreserveReferences();
                cfg.CreateMap<StateDto, State>().PreserveReferences();
            });
        }
    }
}
