using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class Book
    {  
        //Created Crud based off this
        [Key]
        public String UniqueNumber { get; set; }
        public String Title { get; set; }
        public Int32 Price { get; set; }
        public DateTime PublicationDate { get; set; }
        public Genre Genre { get; set; }
        public virtual Author Author { get; set; }
    }
}