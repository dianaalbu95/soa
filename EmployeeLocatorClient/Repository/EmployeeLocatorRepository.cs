using EmployeeLocator.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Web;
using System.Web.Script.Serialization;

namespace EmployeeLocator.Repository
{
    public class EmployeeLocatorRepository : IEmployeeLocatorRepository
    {
        private Uri url = new Uri("http://localhost:3000/");

        public IEnumerable<EmployeeLocatorViewModel> GetEmployeeLocator()
        {
            IEnumerable<EmployeeLocatorViewModel> employees = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = url;

                var responseTask = client.GetAsync("employeeLocator");
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var data = result.Content.ReadAsStringAsync();
                    employees = JsonConvert.DeserializeObject<IList<EmployeeLocatorViewModel>>(data.Result);
                }
                else
                {
                    employees = Enumerable.Empty<EmployeeLocatorViewModel>();
                }

                return employees;
            }
        }

        public EmployeeLocatorViewModel CreateEmployeeLocator(EmployeeLocatorViewModel employeeLocator)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = url;

                var content = new StringContent(JsonConvert.SerializeObject(employeeLocator));
                content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue("application/json");

                var request = client.PostAsync("employeeLocator", content);

                var response = request.Result.Content.ReadAsStringAsync().Result;

                return JsonConvert.DeserializeObject<EmployeeLocatorViewModel>(response);
            }
        }
    }
}