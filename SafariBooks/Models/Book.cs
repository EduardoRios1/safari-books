using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class Book
    {  
        
        [Key]
        [Required]
        public int UniqueNumber { get; set; }

        [Required]
        public String Title { get; set; }

        [Required]
        public Int32 Price { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }

        public Genre Genre { get; set; }

        public virtual Author Author { get; set; }

        public Book(string inputName, Genre SongGenres)
        {
            Title = inputName;
            Genre = SongGenres;
        }

        public Book() 
        {
        }
    }
}