using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace UserManagementEntities
{
    public class Roles
    {
        [Key]
        public int Id { get; set; }
        public string Role { get; set; }        
        public DateTime Createdon { get; set; }
        public DateTime LastModifiedon { get; set; }
        public ICollection<RolePermissions> RolePermissions { get; set; }
        public ICollection<UserRoles> UserRoles { get; set; }
    }
}
