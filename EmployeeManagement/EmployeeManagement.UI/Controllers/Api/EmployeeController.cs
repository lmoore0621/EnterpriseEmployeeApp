using EmployeeManagement.Service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace EmployeeManagement.UI.Controllers.Api
{
    public class EmployeeController : ApiController
    {
        private EmployeeManagementService service;
        private int medianPage = 5;

        public EmployeeController()
        {
            service = new EmployeeManagementService();
        }

        [HttpGet]
        public EmployeeResponse GetAllEmployees(int? pageNumber = null, int? pageSize = null)
        {
            EmployeeRequest request = new EmployeeRequest(EmployeeRequestType.GetAllEmployees)
            {
                PageItems = true,
                PageNumber = pageNumber,
                PageSize = pageSize,
                MedianPage = medianPage
            };

            EmployeeResponse response = service.DoRequest(request);

            return response;
        }
    }
}
