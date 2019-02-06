using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EmployeeLocator.Models
{
    public class EmployeeLocatorViewModel
    {
        public string id { get; set; }
        public string firstName { get; set; }
        public string lastName { get; set; }
        public string city { get; set; }
        public string building { get; set; }
        public string floor { get; set; }
    }
}