using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Http;
using System.Web.Http.Description;
using Bookshop.Data;
using Bookshop.Models;

namespace Bookshop.WebAPI
{
    public class BooksController : ApiController
    {
        private BookshopContext db = new BookshopContext();

        /// <summary>
        /// Returns all books from the Books tables.
        /// </summary>
        /// <returns>All books in collection.</returns>
        // GET: api/Books
        public IQueryable<Book> GetBooks()
        {
            return db.Books;
        }

        /// <summary>
        /// Gets a specific book based on ID passed in.
        /// </summary>
        /// <param name="id">ID of requested book.</param>
        /// <returns>Singular book requested.</returns>
        // GET: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> GetBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            return Ok(book);
        }

        /// <summary>
        /// Updates the particular book with the information provided.
        /// </summary>
        /// <param name="id">ID of the book to be updated.</param>
        /// <param name="book">Updated book object.</param>
        /// <returns>Book object after update.</returns>
        // PUT: api/Books/5
        [ResponseType(typeof(void))]
        public async Task<IHttpActionResult> PutBook(int id, Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != book.Id)
            {
                return BadRequest();
            }

            db.Entry(book).State = EntityState.Modified;

            try
            {
                await db.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!BookExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        /// <summary>
        /// Creates a new book in the Books table.
        /// </summary>
        /// <param name="book">Book object to be inserted.</param>
        /// <returns>New book object as it appears in the collection.</returns>
        // POST: api/Books
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> PostBook(Book book)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Books.Add(book);
            await db.SaveChangesAsync();

            return CreatedAtRoute("DefaultApi", new { id = book.Id }, book);
        }

        /// <summary>
        /// Deletes specified book from Books table.
        /// </summary>
        /// <param name="id">ID of book to be deleted.</param>
        /// <returns></returns>
        // DELETE: api/Books/5
        [ResponseType(typeof(Book))]
        public async Task<IHttpActionResult> DeleteBook(int id)
        {
            Book book = await db.Books.FindAsync(id);
            if (book == null)
            {
                return NotFound();
            }

            db.Books.Remove(book);
            await db.SaveChangesAsync();

            return Ok(book);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool BookExists(int id)
        {
            return db.Books.Count(e => e.Id == id) > 0;
        }
    }
}