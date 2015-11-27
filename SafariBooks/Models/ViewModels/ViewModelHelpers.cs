using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafariBooks.Models;
using SafariBooks.Utilities;

namespace SafariBooks.Models.ViewModels
{
    public static class ViewModelHelpers
    {
        public static BookCreateViewModel ToViewModel(this Book book)
        {
            BookCreateViewModel  newBook = new BookCreateViewModel();
            newBook.Title = book.Title;
            newBook.PublicationDate = book.PublicationDate;
            newBook.UniqueNumber = book.UniqueNumber;
            newBook.Author = book.Author;
            newBook.SelectedGenre = book.Genre.GenreID;
            newBook.SelectedAuthor = book.Author.AuthorID;

            //return the ViewModel
            return newBook;
        }

        public static Book ToDomainModel(this BookCreateViewModel bookCreateViewModel)
        {
            Book book = new Book(bookCreateViewModel.Title, bookCreateViewModel.Genre);
            book.UniqueNumber = bookCreateViewModel.UniqueNumber;
            book.Author = bookCreateViewModel.Author;
            book.PublicationDate = bookCreateViewModel.PublicationDate;
            //song.Genres = UpdateGenres.GetGenresFromIntList(songCreateViewModel.SelectedGenres);
            return book;
        }
    }
}