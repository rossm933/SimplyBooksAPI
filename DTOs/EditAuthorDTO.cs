namespace SimplyBooksAPI.DTOs
{
    public class EditAuthorDTO
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public bool Favorite { get; set; }
    }
}
