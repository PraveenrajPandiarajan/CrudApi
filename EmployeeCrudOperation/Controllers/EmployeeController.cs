using EmployeeCore.Core.Model;
using Microsoft.AspNetCore.Mvc;
using System.Reflection;
using static EmployeeService.Service.EmployeeService;
using System.Net.Http.Formatting;
using Newtonsoft.Json;
using EmployeeEntity.Entity;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace EmployeeCrudOperation.Controllers
{
    public class EmployeeController : Controller
    {


        #region create
        [HttpGet]
        public IActionResult Index()
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7296/api/EmployeeApi/Index");
                var Gettask = client.GetAsync(client.BaseAddress);
                Gettask.Wait();
                var result = Gettask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<EmployeeLocation>>();
                    readTask.Wait();
                    ViewBag.Location = readTask.Result;
                }
            }
                    //EmployeeDetailsContext context = new EmployeeDetailsContext();
                    //List<Locations> locations = context.Locations.ToList();
                    //ViewBag.location = new SelectList(locations, "Location_Id", "Location");
                    return View();
        }
        [HttpPost]
        public IActionResult Index(Employee studetails)
        {
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7296/api/EmployeeApi/Index");
                var Posttask = client.PostAsJsonAsync(client.BaseAddress, studetails);
                Posttask.Wait();
                var result = Posttask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }
            return RedirectToAction("Read");
        }
        #endregion

        #region Read
        [HttpGet]
        public IActionResult Read()
        {

            List<Employee> employee = null;
            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7296/api/EmployeeApi/Read");
                var Gettask = client.GetAsync(client.BaseAddress);
                Gettask.Wait();
                var result = Gettask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadFromJsonAsync<IList<Employee>>();
                    readTask.Wait();
                    employee = (List<Employee>?)readTask.Result;
                }
                List<Employee> sortedList = employee.OrderBy(name => name.First_Name).ToList();
                return View(sortedList);
            }  

        }
        #endregion

        #region Search
        [HttpGet]
        public IActionResult Search(string search)
        {

           if (!string.IsNullOrWhiteSpace(search))
            {
                List<Employee> employee = null;
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri("https://localhost:7296/api/EmployeeApi/Search?search=");
                    var Gettask = client.GetAsync(client.BaseAddress + search);
                    Gettask.Wait();
                    var result = Gettask.Result;
                    if (result.IsSuccessStatusCode)
                    {
                        var readTask = result.Content.ReadFromJsonAsync<IList<Employee>>();
                        readTask.Wait();
                        employee = (List<Employee>?)readTask.Result;
                    }
                    return View("Read", employee);
                }
            }
            else
            {
                return RedirectToAction("Read");
            }


        }
        #endregion

        #region Update
        [HttpGet]
        public ActionResult Edit(int Empid)
        {
            Index();
            Employee employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7296/api/EmployeeApi/Edit?Empid=");
                //HTTP GETr
                var responseTask = client.GetAsync(client.BaseAddress + Empid.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();

                    employee = readTask.Result;
                }
            }
            return View("Index", employee);
        }
        #endregion

        #region Delete
        public IActionResult Delete(int EmployeeId)
        {

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7296/api/EmployeeApi/Delete?EmployeeId=");

                //HTTP DELETE
                var deleteTask = client.DeleteAsync(client.BaseAddress + EmployeeId.ToString());
                deleteTask.Wait();
                var result = deleteTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    return RedirectToAction("Read");
                }
            }

            return RedirectToAction("Read");
        }
        #endregion

        #region Detail
        [HttpGet]
        public ActionResult Detail(int Empid)
     {
            Employee employee = null;

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri("https://localhost:7296/api/EmployeeApi/Detail?Empid=");
                //HTTP GETr
                var responseTask = client.GetAsync(client.BaseAddress + Empid.ToString());
                responseTask.Wait();

                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var readTask = result.Content.ReadAsAsync<Employee>();
                    readTask.Wait();

                    employee = readTask.Result;
                }
            }
            return PartialView(employee);
        }

        #endregion

    }


}




    

