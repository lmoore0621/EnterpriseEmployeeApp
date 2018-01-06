using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EmployeeManagement.DTOs;

namespace EmployeeManagement.Web.Controllers.Web
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            return View("Index");
        }

        public ActionResult Home()
        {
            return PartialView();
        }

        public ActionResult Create()
        {
            return PartialView();
        }

        public ActionResult Update()
        {
            return PartialView();
        }
    }
}