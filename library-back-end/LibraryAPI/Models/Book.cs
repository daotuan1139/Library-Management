using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace LibraryAPI.Models
{

    [Table("Book")]
    public class Book
    {
        [Key]
        public int ID { get; set; }

        public string BookName { get; set; }
        
    }
}