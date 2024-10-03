using SimplyBooksAPI.Models;
namespace SimplyBooksAPI.Data
{
    public class BookData
    {
        public static List<Book> Books =
            [
            new() {     Id = 1, Title = "The Adventures of Coding", Image = "https://example.com/images/coding_adventures.jpg", AuthorId = 1, Price = 19.99m, Sale = true, Uid = "user123", Description = "A thrilling journey through the world of coding."    },
            new() {     Id = 2, Title = "Mastering Software Engineering", Image = "https://example.com/images/software_engineering.jpg", AuthorId = 2, Price = 29.99m, Sale = false, Uid = "user456", Description = "A comprehensive guide to becoming a proficient software engineer."},
            new() {     Id = 3, Title = "The Secrets of Clean Code", Image = "https://example.com/images/clean_code_secrets.jpg", AuthorId = 3, Price = 24.99m, Sale = true, Uid = "user789", Description = "An insightful look into writing maintainable and clean code."}
            ];

    }
}
