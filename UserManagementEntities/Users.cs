using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;

namespace UserManagementEntities
{
    public class Users 
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string UserName { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        public string LastName { get; set; }

        [Required]
        [RegularExpression(@"^([\w\.\-]+)@([\w\-]+)((\.(\w){2,3})+)$", ErrorMessage = "Email in not valid")]
        public string Email { get; set; }

        [Required]
        public DateTime DateofBirth { get; set; }

        public int Age { get; set; }

        [Required]
        [RegularExpression("^[0-9]*$", ErrorMessage = "Invalid Phone Number")]
        public string Phone { get; set; }

        [DefaultValue("true")]
        public bool Active { get; set; }

        [Required]
        public string Password { get; set; }

        public DateTime Createdon { get; set; }

        public DateTime LastModifiedon { get; set; }

        public ICollection<UserRoles> UserRoles { get; set; }

        public ICollection<AuditLogs> AuditLogs { get; set; }
    }

}
