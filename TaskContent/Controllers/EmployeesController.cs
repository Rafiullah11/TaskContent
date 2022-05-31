using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using TaskContent.Models;

namespace TaskContent.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeesController : ControllerBase
    {
        [HttpGet(Name = "GetEmployee")]
        public IEnumerable<Employee> Get()
        {
            if (HttpContext.Request.Headers["X-Requested-With"] != "XMLHttpRequest")
            {
                //here we will return View or full view
                var employees = new List<Employee>
                {
                new Employee{Id=1, Name="Rafi",City="Peshawar"},
                new Employee{Id=2, Name="Ali",City="Abbotabad"},
                new Employee{Id=3, Name="Wali",City="Islamabad"},
                };
            return employees;


            }
            else
            {
                //here we will return Partial View 

                return Enumerable.Empty<Employee>();        
            }
             
        }

    }
}
