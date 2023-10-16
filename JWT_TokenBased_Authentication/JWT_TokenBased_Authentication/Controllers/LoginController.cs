using JWT_TokenBased_Authentication.Models;
using log4net;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Text;
using TestProject;

namespace JWT_TokenBased_Authentication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private static readonly ILog Logger = Log4NetHelper.GetLogger(typeof(LoginController)); //LogManager
        private IConfiguration _config;
        public LoginController(IConfiguration config)
        {

            _config = config;
        }

        private Users AuthenticateUser(Users user)
        {
            Users _user = null;
            if(user.Username == "admin" && user.Password == "password")
            {
                _user = new Users { Username = " Aman Shankar" };
            }
            return _user;
        }
        private string GenerateToken(Users user)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var cred = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256); //HmacSha512

            var token = new JwtSecurityToken(_config["Jwt:Issuer"], _config["Jwt:Audience"],null,
                expires: DateTime.Now.AddMinutes(1),signingCredentials:cred);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Login(Users user)
        {
            IActionResult response = Unauthorized();
            var user_ = AuthenticateUser(user);
            if(user_ != null)
            {
                var token = GenerateToken(user_);
                response = Ok(new {token = token});
            }
            if (response is UnauthorizedResult)
            {
                response = Unauthorized("Unauthorized");
                Logger.Error("Log Info :- Unauthorized");
            }
            if (response is OkObjectResult)
            {
                Logger.Info("Log Info :- Authorized");
            }
            return response;
        }
    }
}
