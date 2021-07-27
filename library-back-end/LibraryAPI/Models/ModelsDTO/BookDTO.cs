using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Collections.Generic;
using System.Collections;
namespace LibraryAPI.Models
{
    public class BookDTO
    {
        public int BookID { get; set; }

        public string BookName { get; set; }

    }
}