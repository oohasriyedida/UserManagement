using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserManagementEntities
{
    public class RolePermissions
    {
        [Key]
        public int Id { get; set; }
        public string Permission { get; set; }        
        [ForeignKey("Roles")]
        public int RolesId { get; set; }
    }
}
