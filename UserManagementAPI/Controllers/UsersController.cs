using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using AuthenticationPlugin;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using Microsoft.Extensions.Configuration;
using UserManagementBL;
using UserManagementDAL;
using UserManagementEntities;


namespace UserManagementAPI.Controllers
{

    
    [Route("api/[controller]/[action]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserLogic iUserLogic;
        private IConfiguration _configuration;
        private readonly AuthService _auth;
        private readonly ILoggerManager _logger;
        private UserManagementDbContext _userManagementDbContext;

        public UsersController(IUserLogic _IUserLogic, IConfiguration configuration, ILoggerManager logger, UserManagementDbContext userManagementDbContext)
        {
            _configuration = configuration;
            _auth = new AuthService(_configuration);
            iUserLogic = _IUserLogic;
            _logger = logger;
            _userManagementDbContext = userManagementDbContext;

        }

        [Authorize(Roles = "Admin")]
        [HttpPost]
        public IActionResult AddUser([FromBody] Users user)
        {
            try
            {
                _logger.LogInfo("Adding User");
                var result = iUserLogic.AddUser(user);
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal Server error");
            }
        }

        [HttpPost]
        public IActionResult Login([FromBody] Login user)
        {
            var userEmail = _userManagementDbContext.Users.FirstOrDefault(u => u.Email == user.Email);
            if (userEmail == null)
            {
                return NotFound();
            }
            var UserRole = _userManagementDbContext.UserRoles.FirstOrDefault(u => u.Usersid == userEmail.Id);
            var roletype = _userManagementDbContext.Roles.FirstOrDefault(u => u.Id == UserRole.RolesId);           
            if (user.Password != userEmail.Password)
            {
                return Unauthorized();
            }
            var claims = new[]
            {
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, roletype.Role),
                new Claim(ClaimTypes.Name, user.Email)
            };
            var token = _auth.GenerateAccessToken(claims);
            return new ObjectResult(new
            {
                access_token = token.AccessToken,
                expires_in = token.ExpiresIn,
                token_type = token.TokenType,
                creation_Time = token.ValidFrom,
                expiration_Time = token.ValidTo,
                user_id = userEmail.Id
            });
        }

        [Authorize(Roles = "Admin")]
        [HttpPut("{id}")]
        [ServiceFilter(typeof(LogAttribute))]
        public IActionResult UpdateUser(int id, [FromBody] Users userObj)
        {

            try
            {
                _logger.LogInfo("Updating User information.");
                var result = iUserLogic.UpdateUser(id, userObj);
                _logger.LogInfo("User updated successfully.");
                return Ok(result);
            }
            catch (Exception ex)
            {
                _logger.LogError($"Something went wrong: {ex}");
                return StatusCode(500, "Internal Server error");
            }          
        }

        [Authorize(Roles = "Admin")]
        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            try
            {
                _logger.LogInfo("Updating User information.");
                var result = iUserLogic.DeleteUser(id);                
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
