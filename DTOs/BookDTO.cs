using SimplyBooksAPI.Data;

namespace SimplyBooksAPI.DTOs
{
    public class BookDTO
    {
        public int Id { get; set; }
        public string? Title { get; set; }
        public string? Image { get; set; }
        public decimal Price { get; set; }
        public bool Sale { get; set; }
        public string? Uid { get; set; }
        public string? Description { get; set; }

        public AuthorDTO? Author { get; set; }
    }
}
