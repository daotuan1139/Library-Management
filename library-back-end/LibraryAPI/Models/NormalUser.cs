using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace LibraryAPI.Models
{

    [Table("NormalUser")]
    public class NormalUser
    {
        [Key]
        public int NormalUserID { get; set; }
        public string NormalUserEmail { get; set; }
        public string NormalUserPassword { get; set; }
        public string NormalUserName { get; set; }

    }
}