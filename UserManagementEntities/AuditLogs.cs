using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace UserManagementEntities
{
    public class AuditLogs
    {
        [Key]
        public int Id { get; set; }
        public string Action { get; set; }
        public string TableName { get; set; }
        [Column(TypeName = "xml")]
        public string Logs { get; set; }
        public DateTime CurrentDate { get; set; }
        [ForeignKey("Users")]
        public int Usersid { get; set; }
    }
}
