using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using EmployeeManagement.Service;

namespace EmployeeManagement.Web.Controllers.Api
{
    [RoutePrefix("api/general")]
    public class GeneralController : ApiController
    {
        public EmployeeManagementService service;

        public GeneralController()
        {
            service = new EmployeeManagementService();
        }

        [HttpGet]
        [Route("options/states")]
        public GeneralResponse GetStateOptions()
        {
            GeneralRequest request = new GeneralRequest(GeneralRequestType.GetStateOptions);

            GeneralResponse response = service.DoRequest(request);

            return response;
        }

        [HttpGet]
        [Route("options/degrees")]
        public GeneralResponse GetDegreeOptions()
        {
            GeneralRequest request = new GeneralRequest(GeneralRequestType.GetDegreeOptions);

            GeneralResponse response = service.DoRequest(request);

            return response;
        }

        [HttpGet]
        [Route("options/genders")]
        public GeneralResponse GetGenderOptions()
        {
            GeneralRequest request = new GeneralRequest(GeneralRequestType.GetGenderOptions);

            GeneralResponse response = service.DoRequest(request);

            return response;
        }
    }
}
