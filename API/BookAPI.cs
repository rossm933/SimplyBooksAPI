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
        }
    }
}
