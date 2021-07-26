using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace LibraryAPI.Models
{

    [Table("BookBorrowingRequestDetail")]
    public class BookBorrowingRequestDetail
    {   
        public int UserID { get; set; } 
        public User User {get; set;}
        public int BookBorrowingRequestID { get; set; }
        public BookBorrowingRequest BookBorrowingRequest {get; set;}
    }
}