using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class Genre
    {
        [Required]
        [Key]
        public int GenreID { get; set; }

        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        public List<Author> Authors { get; set;}

        public List<Book> Books { get; set; }
    }
}