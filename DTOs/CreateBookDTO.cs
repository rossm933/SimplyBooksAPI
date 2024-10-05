namespace SimplyBooksAPI.DTOs
{
    public class CreateBookDTO
    {
        public string? Title { get; set; }
        public int AuthorId { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public bool Sale { get; set; }
        public string? Description { get; set; }
    }
}
