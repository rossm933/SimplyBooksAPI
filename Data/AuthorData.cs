using SimplyBooksAPI.Models;

namespace SimplyBooksAPI.Data
{
    public class AuthorData
    {
        public static List<Author> Authors =
            [
            new() {    Id = 1, Email = "emily.brown@example.com", FirstName = "Emily", LastName = "Brown", Image = "https://example.com/images/emily_brown.jpg", Favorite = true, Uid = "user333"},
            new() {    Id = 2, Email = "michael.green@example.com", FirstName = "Michael", LastName = "Green", Image = "https://example.com/images/michael_green.jpg", Favorite = false, Uid = "user444" },
            new() {    Id = 3, Email = "sophia.wilson@example.com", FirstName = "Sophia", LastName = "Wilson", Image = "https://example.com/images/sophia_wilson.jpg", Favorite = true, Uid = "user555"}
            ];
    }
}
