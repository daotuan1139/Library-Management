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
        public string UserName { get; set; }

        public ICollection<BookBorrowingRequestDetail> BorrowingRequestDetails { get; set; }

    }
}