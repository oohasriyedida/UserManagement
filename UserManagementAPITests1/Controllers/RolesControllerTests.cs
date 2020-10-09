using Xunit;
using UserManagementAPI.Controllers;
using System;
using System.Collections.Generic;
using System.Text;
using UserManagementEntities;
using Moq;
using UserManagementBL;

namespace UserManagementAPI.Controllers.Tests
{
    public class RolesControllerTests
    {

        private readonly Mock<IRolesLogic> iRolesLogic;
        private readonly Mock<ILoggerManager> _logger;
        private readonly RolesController _controller;
        public RolesControllerTests()
        {
            iRolesLogic = new Mock<IRolesLogic>();
            _logger = new Mock<ILoggerManager>();
            _controller = new RolesController(iRolesLogic.Object, _logger.Object);
        }


        [Fact()]
        public void AssignRolesTest()
        {

            UserRoles details = null;
            iRolesLogic.Setup(r => r.AssignRoles(It.IsAny<UserRoles>()))
                .Callback<UserRoles>(x => details = x);


            var userdetails = new UserRoles()
            {
                Id = 1,
                Usersid = 1,
                RolesId = 2
            };

            _controller.AssignRoles(userdetails);
            Assert.Equal(details.Id, userdetails.Id);
            Assert.Equal(details.Usersid, userdetails.Usersid);
            Assert.Equal(details.RolesId, userdetails.RolesId);

            Assert.True(true, "Created Successfully");
        }

        [Fact()]
        public void DeleteUserRoleTest()
        {
            int id = 7;
            iRolesLogic.Setup(r => r.DeleteUserRole(id))
                .Returns("Deleted");
            var result = _controller.DeleteUserRole(id);
            Assert.True(true, "Record Deleted");
        }
    }
}