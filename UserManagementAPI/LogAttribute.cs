using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Http.Extensions;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagementDAL;
using UserManagementEntities;

namespace UserManagementAPI
{
    public class LogAttribute : ActionFilterAttribute
    {
        protected DateTime start_time;
        private readonly UserManagementDbContext _context;

        public LogAttribute(UserManagementDbContext userManagementDbContext)
        {
            _context = userManagementDbContext;

        }
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            start_time = DateTime.Now;
            
            //Stores the Request in an Accessible object
            var request = filterContext.HttpContext.Request;
            
            if (filterContext.HttpContext.User.Identity.IsAuthenticated)
            {                
                var userWithEmail = _context.Users.Where(u => u.Email == filterContext.HttpContext.User.Identity.Name).SingleOrDefault();
                //Generate an audit
                AuditLogs audit = new AuditLogs()
                {
                    Usersid = userWithEmail.Id,
                    TableName = request.QueryString.Value,
                    Action = ((ControllerBase)filterContext.Controller).ControllerContext.ActionDescriptor.ControllerName + "/" + ((ControllerBase)filterContext.Controller).ControllerContext.ActionDescriptor.ActionName,
                    CurrentDate = DateTime.UtcNow
                };

                //Stores the Audit in the Database
                _context.AuditLogs.Add(audit);
                _context.SaveChanges();

                //Finishes executing the Action as normal 
                 base.OnActionExecuting(filterContext);
            }        
        }       
    }
}
