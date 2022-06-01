using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskContent.Models;

namespace TaskContent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : Controller
    {
        [HttpGet(Name = "GetEmployee")]
        public IEnumerable<Employee> Get()
        { //here we will return View or full view
                var employees = new List<Employee>
                {
                new Employee{Id=1, Name="Rafi",City="Peshawar"},
                new Employee{Id=2, Name="Ali",City="Abbotabad"},
                new Employee{Id=3, Name="Wali",City="Islamabad"},
                };

                return employees;

        }
        [HttpGet(Name = "ViewMethod")]
        public IActionResult ViewMethod()
        {
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                return View();
            }
            else
            {
                return PartialView(HttpContext.Request);
            }
        }
        [HttpGet(Name = "GetMethod")]
        public IActionResult GetMethod()
        {
            if (HttpContext.Request.Headers["Accept"] == "application/json")
                return Ok();
            else if (HttpContext.Request.Headers["Accept"] == "application/xml")
                return Ok();
            else if (HttpContext.Request.Headers["Accept"] == "text/plain")
                return Ok();
            return Ok();


        }

    }
}
