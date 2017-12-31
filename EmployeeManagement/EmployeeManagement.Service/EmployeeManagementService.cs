using System.Collections.Generic;
using EmployeeManagement.Model.Services;
using EmployeeManagement.Data;
using EmployeeManagement.Model;
using EmployeeManagement.DTOs;
using System;
using AutoMapper;

namespace EmployeeManagement.Service
{
    public class EmployeeManagementService : BaseService
    {
        private Dictionary<EmployeeRequestType, string> employeeDefaultErrorMessages;
        private Dictionary<EmployeeRequestType, string> employeeDefaultSuccessMessages;

        private Dictionary<GeneralRequestType, string> generalDefaultErrorMessages;
        private Dictionary<GeneralRequestType, string> generalDefaultSuccessMessages;

        private IEmployeeService employeeService;
        private IGeneralService generalService;

        public EmployeeManagementService()
        {
            SetDefaultMessages();
            employeeService = new EmployeeService(new EmployeeUnitOfWork(new DataSource()));
            generalService = new GeneralService(new GeneralUnitOfWork(new DataSource()));
        }

        public GeneralResponse DoRequest(GeneralRequest request)
        {
            GeneralResponse response = new GeneralResponse();

            try
            {
                switch (request.Type)
                {
                    case GeneralRequestType.GetDegreeOptions:
                        response = GetDegreeOptions(request);
                        break;
                    case GeneralRequestType.GetGenderOptions:
                        response = GetGenderOptions(request);
                        break;
                    case GeneralRequestType.GetStateOptions:
                        response = GetStateOptions(request);
                        break;
                }

                response.Successful = true;
                response.Message = generalDefaultSuccessMessages[request.Type];
            }
            catch (Exception ex)
            {
                GetExceptionInfo(ex, response, generalDefaultErrorMessages[request.Type]);
            }

            return response;
        }

        public EmployeeResponse DoRequest(EmployeeRequest request)
        {
            EmployeeResponse response = new EmployeeResponse();

            try
            {
                switch (request.Type)
                {
                    case EmployeeRequestType.CreateEmployee:
                        response = CreateEmployee(request);
                        break;
                    case EmployeeRequestType.DeleteEmployee:
                        response = DeleteEmployee(request);
                        break;
                    case EmployeeRequestType.GetAllEmployees:
                        response = GetAllEmployees(request);
                        break;
                    case EmployeeRequestType.GetEmployee:
                        response = GetEmployee(request);
                        break;
                    case EmployeeRequestType.UpdateEmployee:
                        response = UpdateEmployee(request);
                        break;
                }

                response.Successful = true;
                response.Message = employeeDefaultSuccessMessages[request.Type];
            } 
            catch(Exception ex)
            {
                GetExceptionInfo(ex, response, employeeDefaultErrorMessages[request.Type]);
            }

            return response;
        }

        #region General Request Operations

        private GeneralResponse GetStateOptions(GeneralRequest request)
        {
            GeneralResponse response = new GeneralResponse();

            IEnumerable<State> states = generalService.GetStateOptions();

            response.StateOptions = Mapper.Map<IEnumerable<StateDto>>(states);

            return response;
        }

        private GeneralResponse GetGenderOptions(GeneralRequest request)
        {
            GeneralResponse response = new GeneralResponse();

            IEnumerable<Gender> genders = generalService.GetGenderOptions();

            response.GenderOptions = Mapper.Map<IEnumerable<GenderDto>>(genders);

            return response;
        }

        private GeneralResponse GetDegreeOptions(GeneralRequest request)
        {
            GeneralResponse response = new GeneralResponse();

            IEnumerable<Gender> genders = generalService.GetGenderOptions();

            response.GenderOptions = Mapper.Map<IEnumerable<GenderDto>>(genders);

            return response;
        }

        #endregion

        #region Employee Request Operations

        private EmployeeResponse UpdateEmployee(EmployeeRequest request)
        {
            EmployeeResponse response = new EmployeeResponse();

            Employee employee = Mapper.Map<Employee>(request.Employee); 
            employeeService.UpdateEmployee(employee);

            return response;
        }

        private EmployeeResponse GetEmployee(EmployeeRequest request)
        {
            EmployeeResponse response = new EmployeeResponse();

            Employee employee = employeeService.GetEmployee(request.EmployeeId); ;

            response.Employee = Mapper.Map<EmployeeDto>(employee);

            return response;
        }

        private EmployeeResponse GetAllEmployees(EmployeeRequest request)
        {
            EmployeeResponse response = new EmployeeResponse();

            IEnumerable<Employee> employees = employeeService.GetAllEmployees(request.Skip, request.Take);

            if (request.PageItems)
            {
                response.PagingInfo = GetPagingInfo(request, employeeService.EmployeesFound);
            }

            response.Employees = Mapper.Map<IEnumerable<EmployeeDto>>(employees);

            return response;
        }

        private EmployeeResponse DeleteEmployee(EmployeeRequest request)
        {
            EmployeeResponse response = new EmployeeResponse();

            employeeService.DeleteEmployee(request.EmployeeId);

            return response;
        }

        private EmployeeResponse CreateEmployee(EmployeeRequest request)
        {
            EmployeeResponse response = new EmployeeResponse();

            Employee employee = Mapper.Map<Employee>(request.Employee);
            employeeService.CreateEmployee(employee);

            return response;
        }

        #endregion

        #region Helper Methods 

        public void SetDefaultMessages()
        {
            string errorPrefix = "An unknown error occurred ";
            
            employeeDefaultErrorMessages = new Dictionary<EmployeeRequestType, string>();
            employeeDefaultErrorMessages.Add(EmployeeRequestType.CreateEmployee, errorPrefix + "creating employee.");
            employeeDefaultErrorMessages.Add(EmployeeRequestType.DeleteEmployee, errorPrefix + "deleting employee.");
            employeeDefaultErrorMessages.Add(EmployeeRequestType.GetAllEmployees, errorPrefix + "getting all employees.");
            employeeDefaultErrorMessages.Add(EmployeeRequestType.GetEmployee, errorPrefix + "getting employee.");
            employeeDefaultErrorMessages.Add(EmployeeRequestType.UpdateEmployee, errorPrefix + "updating employee.");

            employeeDefaultSuccessMessages = new Dictionary<EmployeeRequestType, string>();
            employeeDefaultSuccessMessages.Add(EmployeeRequestType.CreateEmployee, "Employee was created successfully.");
            employeeDefaultSuccessMessages.Add(EmployeeRequestType.DeleteEmployee, "Employee was deleted successfully.");
            employeeDefaultSuccessMessages.Add(EmployeeRequestType.GetAllEmployees, "All employees were retrieved successfully.");
            employeeDefaultSuccessMessages.Add(EmployeeRequestType.GetEmployee, "Employee was retrieved successfully.");
            employeeDefaultSuccessMessages.Add(EmployeeRequestType.UpdateEmployee, "Employee was updated successfully.");

            generalDefaultErrorMessages = new Dictionary<GeneralRequestType, string>();
            generalDefaultErrorMessages.Add(GeneralRequestType.GetDegreeOptions, errorPrefix + "getting degree options.");
            generalDefaultErrorMessages.Add(GeneralRequestType.GetGenderOptions, errorPrefix + "getting gender options.");
            generalDefaultErrorMessages.Add(GeneralRequestType.GetStateOptions, errorPrefix + "getting state options.");

            generalDefaultSuccessMessages = new Dictionary<GeneralRequestType, string>();
            generalDefaultSuccessMessages.Add(GeneralRequestType.GetDegreeOptions, "Degree options were retrieved successfully.");
            generalDefaultSuccessMessages.Add(GeneralRequestType.GetGenderOptions, "Gender options were retrieved successfully.");
            generalDefaultSuccessMessages.Add(GeneralRequestType.GetStateOptions, "State options were retrieved successfully.");
        }

        #endregion

    }
}
