using JWT_TokenBased_Authentication.Controllers;
using JWT_TokenBased_Authentication.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Moq;

namespace MockTesting_TokenBased_Authentication
{
    public class UnitTest1
    {
        /*[Fact]
        public void Login_ValidUser_ReturnsOkResultWithToken()
        {
            // Arrange
            var config = new Mock<IConfiguration>();
            config.SetupGet(c => c["Jwt:Key"]).Returns("your-secret-key");

            var logger = new Mock<ILogger<LoginController>>();

            var controller = new LoginController(config.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            var user = new Users
            {
                Username = "admin",
                Password = "password"
            };

            // Act
            var result = controller.Login(user);

            // Assert
            var okResult = Assert.IsType<OkObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(okResult.Value);
            Assert.Equal("Authorized", response.Message);
            Assert.NotNull(response.Data);
        }

        [Fact]
        public void Login_InvalidUser_ReturnsUnauthorizedResult()
        {
            // Arrange
            var config = new Mock<IConfiguration>();
            config.SetupGet(c => c["Jwt:Key"]).Returns("your-secret-key");

            var logger = new Mock<ILogger<LoginController>>();

            var controller = new LoginController(config.Object)
            {
                ControllerContext = new ControllerContext()
                {
                    HttpContext = new DefaultHttpContext()
                }
            };

            var user = new Users
            {
                Username = "invalidUser",
                Password = "invalidPassword"
            };

            // Act
            var result = controller.Login(user);

            // Assert
            var unauthorizedResult = Assert.IsType<UnauthorizedObjectResult>(result);
            var response = Assert.IsType<ApiResponse>(unauthorizedResult.Value);
            Assert.Equal("Unauthorized", response.Message);
            Assert.Null(response.Data);
        }*/

        [Fact]
        public void EmployeeController_GetData_ValidResult()
        {
            //Arrange
            EmployeeController employeeController = new EmployeeController();
            string expectedResult = "Authenticated with JWT";
            //Act
            string result = employeeController.GetData();
            //Assert
            Assert.Equal(expectedResult, result);
        }
        [Fact]
        public void EmployeeController_Details_ValidResult()
        {
            //Arrange
            EmployeeController employeeController = new EmployeeController();
            string expectedResult = "Without Authentication";
            //Act
            string result = employeeController.Details();
            //Assert
            Assert.Equal(expectedResult, result);
        }
        /*[Fact]
        public void EmployeeController_AddUser_ValidResult()
        {
            //Arrange
            EmployeeController employeeController = new EmployeeController();
            var user = new Users
            {
                Username = "admin",
                Password = "password"
            };
            string expectedResult = "User added with Username" + user;
            //Act
            string result = employeeController.AddUser(user);
            //Assert
            Assert.Equal(expectedResult, result);
        }*/
    }
}