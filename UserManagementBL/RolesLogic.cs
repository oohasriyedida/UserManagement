using System;
using System.Collections.Generic;
using System.Text;
using UserManagementDAL;
using UserManagementEntities;

namespace UserManagementBL
{
    public class RolesLogic : IRolesLogic
    {
        private readonly IRolesDb iRolesDb;
        public RolesLogic(IRolesDb _IRolesDb)
        {
            iRolesDb = _IRolesDb;
        }

        public string AssignRoles(UserRoles role)
        {
            return iRolesDb.AssignRoles(role);
        }

        public string UpdateUserRoles(int id, UserRoles rolesObj)
        {
            return iRolesDb.UpdateUserRoles(id, rolesObj);
        }

        public string DeleteUserRole(int id)
        {
            return iRolesDb.DeleteUserRole(id);
        }
    }
}
