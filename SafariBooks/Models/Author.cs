using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Models
{
    public class Author
    {
        [Required]
        public int AuthorID { get; set; }

        [Required]
        [Display(Name = "First Name")]
        public String FName { get; set; }

        [Display(Name = "Last Name")]
        public String LName { get; set; }

        public List<Book> Books { get; set; }

        public string FullName
        {
            get { return string.Format("{0} {1}", FName, LName); }
        }

    }
}