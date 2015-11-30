using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

//A ViewModel to help us create a Book
namespace SafariBooks.Models.ViewModels
{
    public class BookCreateViewModel
    {
        public int BookID { get; set; }
        [Required]
        public int UniqueNumber { get; set; }

        [Required]
        public string Title { get; set; }

        public Author Author { get; set; }

        public Genre Genre { get; set; }

        [Required]
        public virtual List<Genre> BookGenres { get; set; }

        [Required]
        public Int32 Price { get; set; }

        [Required]
        public DateTime PublicationDate { get; set; }
      
        //Genres selected by the user
        //private List<int> _selectedGenres { get; set; }

        //Genre that they select
        public int SelectedGenre {get;set;}

        //Author that they select
        [Required]
        public int SelectedAuthor { get; set; }


        public BookCreateViewModel()
        {
            // add an empty list so there is an add method
            BookGenres = new List<Genre>();
        }

      
    }
}