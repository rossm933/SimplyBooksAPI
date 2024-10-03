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
            app.MapPost("/book", (SimplyBooksAPIDbContext db, CreateBookDTO bookDTO) =>
            {
                var newBook = new Book
                {
                    Title = bookDTO.Title,
                    Description = bookDTO.Description,
                    Image = bookDTO.Image,
                    Price = bookDTO.Price,
                    Sale = bookDTO.Sale,
                    Uid = bookDTO.Uid,
                    AuthorId = bookDTO.AuthorId
                };

                db.Books.Add(newBook);
                db.SaveChanges();

                return Results.Created($"/book/{newBook.Id}", newBook);
            });

            // Update Book
            app.MapPut("/book/{id}", (SimplyBooksAPIDbContext db, int id, UpdateBookDTO bookDTO) =>
            {
                var bookToUpdate = db.Books.Include(b => b.Author).FirstOrDefault(b => b.Id == id);
                if (bookToUpdate == null)
                {
                    return Results.NotFound("Book not found");
                }

                // Manually map properties from bookDTO to bookToUpdate
                bookToUpdate.Title = bookDTO.Title; // assuming Book has a Title property
                bookToUpdate.AuthorId = bookDTO.AuthorId; // assuming Book has an AuthorId property
                bookToUpdate.Image = bookDTO.Image; // assuming Book has an Image property
                bookToUpdate.Price = bookDTO.Price; // assuming Book has a Price property
                bookToUpdate.Sale = bookDTO.Sale; // assuming Book has a Sale property
                bookToUpdate.Description = bookDTO.Description; // assuming Book has a Description property

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

        }
    }
}
