using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UserManagementEntities;

namespace UserManagementDAL
{
    public class UserDb : IUserDb
    {
        private readonly UserManagementDbContext _context;
        public UserDb(UserManagementDbContext context)
        {
            _context = context ?? throw new ArgumentNullException(nameof(context));
        }
        public string AddUser(Users user)
        {            
            int Result;
            var userWithSameEmail = _context.Users.Where(u => u.Email == user.Email).SingleOrDefault();
            if (userWithSameEmail != null)
            {
                return "User with same email already exists";
            }
            var userObj = new Users
            {
                UserName = user.UserName,
                FirstName = user.FirstName,
                LastName = user.LastName,
                Email = user.Email,
                DateofBirth = user.DateofBirth,
                Age = user.Age,
                Phone = user.Phone,
                Active = user.Active,
                Password = user.Password,
                Createdon = DateTime.Now,
                LastModifiedon = DateTime.Now,
            };
            _context.Users.Add(userObj);
            Result = _context.SaveChanges();
            return "User Created Successfully";
        }

        public string UpdateUser(int id, Users userObj)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return "No record found against this Id";
            }                       
            user.UserName = userObj.UserName;
            user.FirstName = userObj.FirstName;
            user.LastName = userObj.LastName;
            user.Email = userObj.Email;
            user.DateofBirth = userObj.DateofBirth;
            user.Age = userObj.Age;
            user.Phone = userObj.Phone;
            user.Active = userObj.Active;
            user.Password = userObj.Password;
            user.LastModifiedon = DateTime.Now;
             _context.SaveChanges();
            return "Recorde updated successfully.";
        }
        
        public string DeleteUser(int id)
        {
            var user = _context.Users.Find(id);
            if (user == null)
            {
                return "No record found against this Id";
            }
            _context.Users.Remove(user);
            _context.SaveChanges();
            return "Recorde deleted successfully.";
        }
    }
}
