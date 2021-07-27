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
        public int BookID { get; set; } 
        public int? number { get; set; }
        public Book Book {get; set;}
        public int BookBorrowingRequestID { get; set; }
        public BookBorrowingRequest BookBorrowingRequest {get; set;}
    }
}