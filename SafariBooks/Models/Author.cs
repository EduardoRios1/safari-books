using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SafariBooks.Models
{
    public class Author
    {
        public int AuthorID { get; set; }
        public String FName { get; set; }
        public String LName { get; set; }
        public List<Book> Books { get; set; }

    }
}