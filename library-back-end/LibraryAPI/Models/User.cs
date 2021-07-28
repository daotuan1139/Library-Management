using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace LibraryAPI.Models
{

    [Table("User")]
    public class User
    {
        [Key]
        public int UserID { get; set; }
        public string UserEmail { get; set; }
        public string UserPassword { get; set; }
        public string UserName { get; set; }
        public bool RoleAdmin { get; set; }
        public ICollection<BookBorrowingRequest> BookBorrowingRequests { get; set; } 

    }
}