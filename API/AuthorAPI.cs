﻿using SimplyBooksAPI.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using SimplyBooksAPI.DTOs;
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
            app.MapPost("/authors", (SimplyBooksAPIDbContext db, CreateAuthorDTO newAuthorDTO) =>
            {
                // Manually create a new Author object and assign properties from newAuthorDTO
                var newAuthor = new Author
                {
                    Email = newAuthorDTO.Email,
                    FirstName = newAuthorDTO.FirstName,
                    LastName = newAuthorDTO.LastName,
                    Image = newAuthorDTO.Image,
                    Favorite = newAuthorDTO.Favorite,
                    Uid = newAuthorDTO.Uid,
                 
                    Books = new List<Book>() 
                };

                try
                {
                    db.Authors.Add(newAuthor);
                    db.SaveChanges();
                    return Results.Created($"/authors/{newAuthor.Id}", newAuthor);
                }
                catch (DbUpdateConcurrencyException)
                {
                    return Results.BadRequest("An error occurred trying to add a new author to the database. Check payload format.");
                }
            });

        }
    }
}
