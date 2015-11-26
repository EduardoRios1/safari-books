using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using SafariBooks.Models;
using System.Web.Mvc;

namespace SafariBooks.Utilities
{
    //These are functions to GetAllAuthors and stuff. Helpful for search and creating a book Might need to change some parts Haven't made Authors Yet
    public static class UpdateAuthors
    {
        public static SelectList GetAllAuthors(AppDbContext db)
        {
            var query = from a in db.Authors
                        orderby a.LName
                        select a;
            List<Author> allAuthors = query.ToList();

            SelectList list = new SelectList(allAuthors, "AuthorID", "Name");

            return list;

        }

        public static SelectList GetAllAuthorsWithAll(AppDbContext db)
        {
            var query = from a in db.Authors
                        orderby a.LName
                        select a;
            List<Author> allAuthors = query.ToList();

            allAuthors.Insert(0, new Author { AuthorID = -1, FName = "All" ,LName = "Authors"});

            SelectList list = new SelectList(allAuthors, "AuthorID", "Name");

            return list;
        }

        public static void AddOrUpdateAuthor(AppDbContext db, Book book, Author AuthorToAdd)
        {
            if (book.Author == AuthorToAdd) //new artist is the same as the original artist
            {
                //do nothing
            }
            else
            {
                book.Author = AuthorToAdd;
            }
        }
    }
}