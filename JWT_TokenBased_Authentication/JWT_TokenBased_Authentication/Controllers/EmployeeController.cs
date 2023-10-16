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
        /*public EmployeeController(ILogger<EmployeeController> logger)
        {
            Logger = logger;
        }*/

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
