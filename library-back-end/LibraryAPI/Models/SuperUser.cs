using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace LibraryAPI.Models
{

    [Table("SuperlUser")]
    public class SuperUser
    {
        [Key]
        public int SuperUserID { get; set; }
        public string SuperUserEmail { get; set; }
        public string SuperUserPassword { get; set; }
        public string SuperUserName { get; set; }

    }
}