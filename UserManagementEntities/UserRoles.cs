using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserManagementEntities
{
    public class UserRoles
    {
        [Key]
        public int Id { get; set; }
        [ForeignKey("Users")]
        public int Usersid { get; set; }
        [ForeignKey("Roles")]
        public int RolesId { get; set; }
    }
}
