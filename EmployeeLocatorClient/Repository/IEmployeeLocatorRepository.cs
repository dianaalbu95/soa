using EmployeeLocator.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeLocator.Repository
{
    public interface IEmployeeLocatorRepository
    {
        IEnumerable<EmployeeLocatorViewModel> GetEmployeeLocator();
        EmployeeLocatorViewModel CreateEmployeeLocator(EmployeeLocatorViewModel employeeLocatorViewModel);
    }
}
