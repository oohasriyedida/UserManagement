using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagementEntities;

namespace UserManagementDAL
{
    public class RolesDb: IRolesDb
    {
        private readonly UserManagementDbContext _context;
        public RolesDb(UserManagementDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }

        public string AssignRoles(UserRoles role)
        {
            int Result;
            var userIsExist = _context.Users.Where(u => u.Id == role.Usersid).SingleOrDefault();
            if (userIsExist == null)
            {
                return "User not found";
            }
            var rolesObj = new UserRoles
            {
                Usersid = role.Usersid,
                RolesId = role.RolesId
            };
            _context.UserRoles.Add(rolesObj);
            Result = _context.SaveChanges();
            return "User Created Successfully";
        }

        public string UpdateUserRoles(int id, UserRoles rolesObj)
        {
            var userRole = _context.UserRoles.Find(id);
            if (userRole == null)
            {
                return "Record not found";
            }
            userRole.RolesId = rolesObj.RolesId;
            _context.SaveChanges();
            return "Recorde updated successfully.";
        }

        public string DeleteUserRole(int id)
        {
            var user = _context.UserRoles.Find(id);
            if (user == null)
            {
                return "No record found against this Id";
            }
            _context.UserRoles.Remove(user);
            _context.SaveChanges();
            return "Recorde deleted successfully.";
        }
    }
}
