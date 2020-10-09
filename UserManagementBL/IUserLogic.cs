using System;
using System.Collections.Generic;
using System.Text;
using UserManagementEntities;

namespace UserManagementBL
{
    public interface IUserLogic
    {
        string AddUser(Users user);

        string UpdateUser(int id, Users userObj);

        string DeleteUser(int id);
    }
}
