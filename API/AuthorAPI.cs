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

        }
    }
}
