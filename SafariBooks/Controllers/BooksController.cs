using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using SafariBooks.Models;
using SafariBooks.Models.ViewModels;
using SafariBooks.Utilities;
using System.ComponentModel.DataAnnotations;

namespace SafariBooks.Controllers
{
    //Look at Longhorn Music as a template
    //Made a Book Controller
    public class BooksController : Controller
    {
        //Get the DbContext to work based off the IdentityModel
        //This took some time to figure out because I created a new DB context and got lost because they was errors everywhere
        private AppDbContext db = new AppDbContext();

        // GET: Books
        public ActionResult Index()
        {
            return View(db.Books.ToList());
            
        }

        // GET: TestView
        public ActionResult TestView(BookCreateViewModel book)
        {
            ViewBag.BookCreate = book;
            return View();

        }

        // GET: Books/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            BookCreateViewModel newBook = new BookCreateViewModel();
            ViewBag.AllAuthors = UpdateAuthors.GetAllAuthors(db);
            ViewBag.AllGenres = UpdateGenres.GetAllGenres(db);
            return View(newBook);
        }

        // POST: Books/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        //Azaam: I made based this Create off of Longhorn Music. Our Genre is different because we can only have one Genre, just like Author
        //Azaam: For some reason the UniqueNumber is coming in null, even though it is in the View already
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "UniqueNumber,Title,Price,PublicationDate,SelectedGenre,SelectedAuthor")] BookCreateViewModel newBook)
        {
            //return RedirectToAction("TestView", newBook);
            //add artest based on id
            newBook.Author = db.Authors.FirstOrDefault(a => a.AuthorID == newBook.SelectedAuthor);
            newBook.Genre = db.Genres.FirstOrDefault(a => a.GenreID == newBook.SelectedGenre);

            //create a book based on the view model
            Book bookToAdd = newBook.ToDomainModel();
            bookToAdd.UniqueNumber = newBook.UniqueNumber;

            //System.Diagnostics.Debug.WriteLine(newBook.UniqueNumber);

            //create a validation context to validate the song
            //ValidationContext vcx = new ValidationContext(bookToAdd);

            //validate the song follows all the rules
            //This is not needed because in her model, there were multiple Genres to Validate
            //IEnumerable<ValidationResult> validResults = bookToAdd.Validate(vcx);

            //if (validResults.Count() == 0)
            //{
            db.Books.Add(bookToAdd);
            db.SaveChanges();
            //}
            //else  //there are validation results so we need to add them to the view model errors
            //{
            //    foreach (ValidationResult vResult in validResults)
            //    {
            //        ModelState.AddModelError("", vResult.ErrorMessage);
            //    }
            //}
        
        }

        // GET: Books/Edit/5
        // Azaam: For some reason, the Genre ID is going Null
        //Azaam: To see more about an error, click View Details on the error, then expand the error and Inner Exception.
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }

            //Converts a book to a BookCreate View Model
            BookCreateViewModel bookToView = book.ToViewModel();
            //Grabs a ViewBag
            ViewBag.AllGenres = UpdateGenres.GetAllGenres(db);
            ViewBag.AllArtists = UpdateAuthors.GetAllAuthors(db);
            return View(bookToView);
        }

        // POST: Books/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UniqueNumber,Title,Price,PublicationDate")] BookCreateViewModel editedBook)
        {
            if (ModelState.IsValid)
            {
                Book originalBook = db.Books.Find(editedBook.UniqueNumber);

                UpdateGenres.AddOrUpdateBookGenre(db, originalBook, db.Genres.FirstOrDefault(a => a.GenreID == editedBook.SelectedGenre));
                UpdateAuthors.AddOrUpdateAuthor(db, originalBook, db.Authors.FirstOrDefault(a => a.AuthorID == editedBook.SelectedAuthor));
                db.Entry(originalBook).CurrentValues.SetValues(editedBook);
                db.SaveChanges();
                return RedirectToAction("Index");
            }

            ViewBag.AllGenres = UpdateGenres.GetAllGenres(db);
            ViewBag.AllAuthors = UpdateAuthors.GetAllAuthors(db);
            return View(editedBook);
        }

        // GET: Books/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Book book = db.Books.Find(id);
            if (book == null)
            {
                return HttpNotFound();
            }
            return View(book);
        }

        // POST: Books/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            Book book = db.Books.Find(id);
            db.Books.Remove(book);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}
