using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using UserManagementBL;
using UserManagementDAL;
using UserManagementEntities;

namespace UserManagementAPI.Controllers
{
    [Route("api/[controller]/[action]")]
    [ApiController]
    [Authorize(Roles = "Admin")]
    public class RolesController : ControllerBase
    {
        private readonly IRolesLogic iRolesLogic;
        private readonly ILoggerManager _logger;
        public RolesController(IRolesLogic _IRolesLogic, ILoggerManager logger)
        {
            iRolesLogic = _IRolesLogic;
            _logger = logger;
        }

        [HttpPost]
        public IActionResult AssignRoles([FromBody] UserRoles role)
        {
            try
            {
                _logger.LogInfo("Updating User information.");
                var result = iRolesLogic.AssignRoles(role);
                _logger.LogInfo("User updated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal Server error");
            }                       
        }       

        [HttpPut("{id}")]
        public IActionResult UpdateUserRoles(int id, [FromBody] UserRoles rolesObj)
        {
            try
            {
                _logger.LogInfo("Updating User information.");
                var result = iRolesLogic.UpdateUserRoles(id, rolesObj);
                _logger.LogInfo("User updated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal Server error");
            }                       
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUserRole(int id)
        {
            try
            {
                _logger.LogInfo("Updating User information.");
                var result = iRolesLogic.DeleteUserRole(id);
                _logger.LogInfo("User updated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal Server error");
            }                        
        }
    }
}
