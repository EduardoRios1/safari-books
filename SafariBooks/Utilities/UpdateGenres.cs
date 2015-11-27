using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafariBooks.Models;
using System.Web.Mvc;


namespace SafariBooks.Utilities
{
    public class UpdateGenres
    {
        public static SelectList GetAllGenres(AppDbContext db)
        {
            var query = from a in db.Genres
                        orderby a.Name
                        select a;
            List<Genre> allAuthors = query.ToList();

            SelectList list = new SelectList(allAuthors, "GenreID", "Name");

            return list;

        }

        public static SelectList GetAllGenresWithAll(AppDbContext db)
        {
            var query = from a in db.Genres
                        orderby a.Name
                        select a;
            List<Genre> allAuthors = query.ToList();


            allAuthors.Insert(0, new Genre { GenreID = -1, Name = "All Genres" });

            SelectList list = new SelectList(allAuthors, "GenreID", "Name");

            return list;

        }

        public static void AddOrUpdateBookGenre(AppDbContext db, Book book, Genre GenreToAdd)
        {
            if (book.Genre == GenreToAdd) //new artist is the same as the original artist
            {
                //do nothing
            }
            else
            {
                book.Genre = GenreToAdd;
            }
        }
    }
}