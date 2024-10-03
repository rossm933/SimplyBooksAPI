﻿using SimplyBooksAPI.Models;
using Microsoft.EntityFrameworkCore;
namespace SimplyBooksAPI.API
{
    public class BookAPI
    {
        public static void Map(WebApplication app)
        {
            app.MapGet("/books", (SimplyBooksAPIDbContext db) =>
            {
                return db.Books.Include(p => p.Author).ToList();

            });

        }
    }
}
