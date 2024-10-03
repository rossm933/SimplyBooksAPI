using SimplyBooksAPI.Models;
namespace SimplyBooksAPI.Data
{
    public class UserData
    {
        public static List<User> Users =
            [
            new() {    Id = 1, UserName = "rossmorgan", Email = "ross.morgan933@gmail.com", Uid = "abc123" },
            new() {    Id = 2, UserName = "asmith", Email = "asmith@example.com", Uid = "xyz789" },
            new() {    Id = 3, UserName = "mwilliams", Email = "mwilliams@example.com", Uid = "lmn456"}
            ];

    }
}
