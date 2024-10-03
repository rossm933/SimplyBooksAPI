using SimplyBooksAPI.Models;
using Microsoft.EntityFrameworkCore;
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
        }
    }
}
