using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.DTOs;
using EmployeeManagement.Service;

namespace EmployeeManagement.Web.Controllers.Api
{
    [RoutePrefix("api/employee")]
    public class EmployeeController : ApiController
    {
        private EmployeeManagementService service;
        private int medianPage = 5;

        public EmployeeController()
        {
            service = new EmployeeManagementService();
        }

        [HttpGet]
        [Route("all")]
        [Route("all/{pageNumber}/{pageSize}")]
        public EmployeeResponse GetAllEmployees(int? pageNumber = null, int? pageSize = null)
        {
            EmployeeRequest request = new EmployeeRequest(EmployeeRequestType.GetAllEmployees)
            {
                PageNumber = pageNumber,
                PageSize = pageSize,
                MedianPage = medianPage
            };

            EmployeeResponse response = service.DoRequest(request);

            return response;
        }

        [HttpGet]
        [Route("{employeeId}")]
        public EmployeeResponse GetEmployee(int employeeId)
        {
            EmployeeRequest request = new EmployeeRequest(EmployeeRequestType.GetEmployee)
            {
                EmployeeId = employeeId
            };

            EmployeeResponse response = service.DoRequest(request);

            return response;
        }

        [HttpPost]
        public EmployeeResponse CreateEmployee(EmployeeDto employee)
        {
            EmployeeRequest request = new EmployeeRequest(EmployeeRequestType.CreateEmployee)
            {
                Employee = employee
            };

            EmployeeResponse response = service.DoRequest(request);

            return response;
        }

        [HttpPut]
        public EmployeeResponse UpdateEmployee(EmployeeDto employee)
        {
            EmployeeRequest request = new EmployeeRequest(EmployeeRequestType.UpdateEmployee)
            {
                Employee = employee
            };

            EmployeeResponse response = service.DoRequest(request);

            return response;
        }

        [HttpDelete]
        [Route("{employeeId}")]
        public EmployeeResponse DeleteeEmployee(int employeeId)
        {
            EmployeeRequest request = new EmployeeRequest(EmployeeRequestType.DeleteEmployee)
            {
                EmployeeId = employeeId
            };

            EmployeeResponse response = service.DoRequest(request);

            return response;
        }

    }
}
