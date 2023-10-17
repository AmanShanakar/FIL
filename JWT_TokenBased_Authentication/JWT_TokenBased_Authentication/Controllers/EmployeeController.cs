using JWT_TokenBased_Authentication.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using TestProject;

namespace JWT_TokenBased_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmployeeController : ControllerBase
    {
        private static readonly ILog Logger = Log4NetHelper.GetLogger(typeof(LoginController));
        private List<Employee> employees; 
        public EmployeeController()
        {
            employees = new List<Employee>
            {
                new Employee { Id = 1, FirstName = "Aman", LastName = "Shankar", Department = "Intern", HireDate = new DateTime(2023, 8, 14) },
                new Employee { Id = 2, FirstName = "Abhimanyu", LastName = "Singh", Department = "IT", HireDate = new DateTime(2019, 8, 10) },
                new Employee { Id = 3, FirstName = "Madhav", LastName = "Tilak", Department = "Domain", HireDate = new DateTime(2019, 8, 10)},
                new Employee { Id = 4, FirstName = "Atulya", LastName = "Karn", Department = "Hr", HireDate = new DateTime(2019, 8, 10)},
            };
        }

        [HttpGet]
        [Route("GetAllEmployee")]
        public ActionResult<IEnumerable<Employee>> GetAllEmployees()
        {
            return Ok(employees); // Return a list of all employees
        }

        [Authorize]
        [HttpGet]
        [Route("GetData")]
        public string GetData()
        {
            var result = "Authenticated with JWT";
            Logger.Info("Log Info :- " + result);
            return result;
        }

        [HttpGet]
        [Route("Details")]
        public string Details()
        {
            var result = "Without Authentication";
            Logger.Info("Log Info :- " + result);
            return result;
        }

        [Authorize]
        [HttpPost]
        [Route("AddUser")]
        public string AddUser(Users user)
        {
            var result = "User added with Username " + user.Username;
            Logger.Info("Log Info :- " + result);
            return result;
        }
    }
}
