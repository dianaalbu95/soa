using EmployeeLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net.Http;
using Newtonsoft.Json;
using System.Net.Http;
using System.Web.Script.Serialization;
using System.Text;
using EmployeeLocator.Repository;

namespace EmployeeLocator.Controllers
{
    public class EmployeeLocatorController : Controller
    {
        IEmployeeLocatorRepository _employeeLocatorRepository;
        
        public EmployeeLocatorController(IEmployeeLocatorRepository employeeLocatorRepository)
        {
            _employeeLocatorRepository = employeeLocatorRepository;
        }

        public EmployeeLocatorController() : this(new EmployeeLocatorRepository()) {}

        public ActionResult Index()
        {
            var employeeLocatorViewModel = _employeeLocatorRepository.GetEmployeeLocator();

            if(!employeeLocatorViewModel.Any())
                    ModelState.AddModelError(string.Empty, "Server error. Please try again");

            return View(employeeLocatorViewModel);
        }

        public ActionResult Create()
        {
            return View();
        }
       
        [HttpPost]
        public ActionResult Create(EmployeeLocatorViewModel employeeLocator)
        {
            var employeeLocatorViewModel = _employeeLocatorRepository.CreateEmployeeLocator(employeeLocator);

            if (employeeLocatorViewModel != null)
                return RedirectToAction("Index");

            else
                ModelState.AddModelError(string.Empty, "Server Error");

            return View(employeeLocatorViewModel);
        }
    }
}