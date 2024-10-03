namespace SimplyBooksAPI.DTOs
{
    public class CreateAuthorDTO
    {
        public string? Email { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Image { get; set; }
        public bool Favorite { get; set; }
        public string? Uid { get; set; }
    }
}
