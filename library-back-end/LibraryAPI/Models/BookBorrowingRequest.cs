using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace LibraryAPI.Models
{

    [Table("BookBorrowingRequest")]
    public class BookBorrowingRequest
    {
        [Key]
        public int BookBorrowingRequestID { get; set; }

        public string NormalUserRequest { get; set; }

        public DateTime DateRequest { get; set; }

        public string status { get; set; }

        public string AdminApproved { get; set; }

        public ICollection<BookBorrowingRequestDetail> BorrowingRequestDetails { get; set; }
    }
}