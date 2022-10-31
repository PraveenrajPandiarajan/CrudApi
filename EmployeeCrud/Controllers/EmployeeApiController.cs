using Microsoft.AspNetCore.Mvc;
using EmployeeCore.Core.IService;
using EmployeeCore.Core.Model;
namespace EmployeeCrud.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class EmployeeApiController : Controller
    {
        private readonly IService _StudentServices;
        public EmployeeApiController(IService services)
        {

            _StudentServices = services;
        }
        #region Create
        [HttpPost]
        public IActionResult Index(Employee student)
        {
            _StudentServices.CreateStudentEntry(student);

            return RedirectToAction("Index");
        }
        #endregion

        #region Read
        [HttpGet]
        public IActionResult Read()
        {
            var value = _StudentServices.Read();
            return Ok(value);
        }
        #endregion

        #region Update
        [HttpGet]
        public IActionResult Edit(int Empid)
        {
            var value = _StudentServices.EditForm(Empid);
            return Ok(value);

        }
        #endregion

        #region Delete
        [HttpDelete]
        public IActionResult Delete(int EmployeeId)
        {
            _StudentServices.DeleteConform(EmployeeId);
            return RedirectToAction("Read");

        }
        #endregion

        #region search
        [HttpGet]
        public IActionResult Search(string search)
        {
            var value = _StudentServices.Search(search);
            return Ok(value);
        }
        #endregion

        #region Delete
        [HttpGet]
        public IActionResult Detail(int Empid)
        {
            var value = _StudentServices.Detail(Empid);
            return Ok(value);
        }
        #endregion

        #region Dropdown
        [HttpGet]
        public IActionResult Index()
        {
            var value = _StudentServices.Dropdown();
            return Ok(value);
        }
        #endregion

    }
}
