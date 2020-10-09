using System;
using System.Collections.Generic;
using System.Text;
using UserManagementDAL;
using UserManagementEntities;

namespace UserManagementBL
{
    public class UserLogic: IUserLogic
    {

        private readonly IUserDb iUserDb;
        public UserLogic(IUserDb _IUserDb)
        {
            iUserDb = _IUserDb;
        }

        public string AddUser(Users user)
        {
            return iUserDb.AddUser(user);
        }

        public string UpdateUser(int id, Users userObj)
        {
            return iUserDb.UpdateUser(id,userObj);
        }

        public string DeleteUser(int id)
        {
            return iUserDb.DeleteUser(id);
        }
    }
}
