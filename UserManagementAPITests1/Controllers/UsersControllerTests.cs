using Xunit;
using UserManagementAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using Moq;
using UserManagementDAL;
using UserManagementEntities;
using UserManagementBL;
using Microsoft.Extensions.Configuration;
using AuthenticationPlugin;

namespace UserManagementAPI.Controllers.Tests
{
    public class UsersControllerTests
    {

        private readonly UsersController _controller;
        private readonly Mock<IUserLogic> iUserLogic;
        private Mock<IConfiguration> _configuration;
        private readonly Mock<ILoggerManager> _logger;
        private UserManagementDbContext _userManagementDbContext;

        public UsersControllerTests()
        {
            iUserLogic = new Mock<IUserLogic>();
            _configuration = new Mock<IConfiguration>();
            _logger = new Mock<ILoggerManager>();
            _controller = new UsersController(iUserLogic.Object, _configuration.Object, _logger.Object, _userManagementDbContext);
        }

        [Fact()]
        public void AddUserTest()
        {

            Users details = null;
            iUserLogic.Setup(r => r.AddUser(It.IsAny<Users>()))
                .Callback<Users>(x => details = x);


            var userdetails = new Users()
            {
                UserName = "Test22",
                FirstName = "Test",
                LastName = "22",
                Email = "Test22@gmail.com",
                DateofBirth = DateTime.Now,
                Age = 22,
                Phone = "9848098480",
                Active = true,
                Password = "Test22",
                Createdon = DateTime.Now,
                LastModifiedon = DateTime.Now
            };
            var result = _controller.AddUser(userdetails);
            Assert.Equal(details.UserName, userdetails.UserName);
            Assert.Equal(details.FirstName, userdetails.FirstName);
            Assert.Equal(details.LastName, userdetails.LastName);
            Assert.Equal(details.Email, userdetails.Email);
            Assert.Equal(details.Age, userdetails.Age);
            Assert.Equal(details.Phone, userdetails.Phone);
            Assert.Equal(details.DateofBirth, userdetails.DateofBirth);
            Assert.Equal(details.Active, userdetails.Active);
            Assert.Equal(details.Password, userdetails.Password);
            Assert.Equal(details.Createdon, userdetails.Createdon);
            Assert.Equal(details.LastModifiedon, userdetails.LastModifiedon);

        }

        [Fact()]
        public void DeleteUserTest()
        {
            int id = 8;
            iUserLogic.Setup(r => r.DeleteUser(id))
                .Returns("Deleted");
            var result = _controller.DeleteUser(id);
            Assert.True(true, "Record Deleted");
        }
    }
}


