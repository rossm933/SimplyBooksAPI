using SimplyBooksAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace SimplyBooksAPI.API
{
    public class AuthorAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/authors", (SimplyBooksAPIDbContext db) =>
            {
                return db.Authors.Include(p => p.Books).ToList();

            });

            app.MapGet("/authors/{id}", (SimplyBooksAPIDbContext db, int id) =>
            {
                var author = db.Authors
                                .Include(a => a.Books)
                                .FirstOrDefault(a => a.Id == id);

                if (author == null)
                {
                    return Results.NotFound();
                }

                return Results.Ok(author);

            });

        }
    }
}
