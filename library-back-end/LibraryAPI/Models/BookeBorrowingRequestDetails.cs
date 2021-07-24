using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace LibraryAPI.Models
{

    [Table("BookeBorrowingRequestDetails")]
    public class BookeBorrowingRequestDetails
    {
        [Key]
        public int ID { get; set; }

        public string BookName { get; set; }
        
    }
}