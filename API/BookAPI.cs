using SimplyBooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SimplyBooksAPI.DTOs;
namespace SimplyBooksAPI.API
{
    public class BookAPI
    {
        public static void Map(WebApplication app)
        {
            // Get all books
            app.MapGet("/books", (SimplyBooksAPIDbContext db) =>
            {
                return db.Books.Include(p => p.Author).ToList();

            });
            
            // Get books by id
            app.MapGet("/books/{id}", (SimplyBooksAPIDbContext db, int id) =>
            {
                var book = db.Books
                                .Include(b => b.Author)
                                .SingleOrDefault(b => b.Id == id);

                if (book == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(book);

            });

            // Create book
            app.MapPost("/books", (SimplyBooksAPIDbContext db, CreateBookDTO bookDTO) =>
            {
                var newBook = new Book
                {
                    Title = bookDTO.Title,
                    Description = bookDTO.Description,
                    Image = bookDTO.Image,
                    Price = bookDTO.Price,
                    Sale = bookDTO.Sale,
                    AuthorId = bookDTO.AuthorId
                };

                db.Books.Add(newBook);
                db.SaveChanges();

                return Results.Created($"/book/{newBook.Id}", newBook);
            });

            // Update Book
            app.MapPut("/books/{id}", (SimplyBooksAPIDbContext db, int id, UpdateBookDTO bookDTO) =>
            {
                var bookToUpdate = db.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
                if (bookToUpdate == null)
                {
                    return Results.NotFound("Book not found");
                }

                
                bookToUpdate.Title = bookDTO.Title;
                bookToUpdate.AuthorId = bookDTO.AuthorId;
                bookToUpdate.Image = bookDTO.Image;
                bookToUpdate.Price = bookDTO.Price;
                bookToUpdate.Sale = bookDTO.Sale;
                bookToUpdate.Description = bookDTO.Description;

                try
                {
                    db.SaveChanges();
                    return Results.Ok(bookToUpdate);
                }
                catch (DbUpdateException)
                {
                    return Results.BadRequest("Error occurred updating book");
                }
            });

            // Delete Book
            app.MapDelete("/books/{id}", (SimplyBooksAPIDbContext db, int id) =>
            {

                var book = db.Books.FirstOrDefault(b => b.Id == id);

                if (book == null)
                {
                    return Results.NotFound("book is null");
                }

                db.Books.Remove(book);
                db.SaveChanges();
                return Results.Ok("book deleted");

            });

        }
    }
}
