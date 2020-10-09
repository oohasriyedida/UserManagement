using System;
using System.Collections.Generic;
using System.Text;
using UserManagementEntities;

namespace UserManagementDAL
{
    public interface IRolesDb
    {
        string AssignRoles(UserRoles role);

        string UpdateUserRoles(int id, UserRoles rolesObj);

        string DeleteUserRole(int id);
    }
}
