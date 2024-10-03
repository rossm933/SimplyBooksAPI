using Microsoft.EntityFrameworkCore;
using SimplyBooksAPI.Models;
using SimplyBooksAPI.Data;

namespace SimplyBooksAPI
{
    public class SimplyBooksAPIDbContext : DbContext
    {
        public DbSet<Author> Authors { get; set; }
        public DbSet<Book> Books { get; set; }

        public SimplyBooksAPIDbContext(DbContextOptions<SimplyBooksAPIDbContext> context) : base(context)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Book>().HasData(BookData.Books);
            modelBuilder.Entity<Author>().HasData(AuthorData.Authors);
            modelBuilder.Entity<User>().HasData(UserData.Users);


            // Define relationship between Author and Books
            modelBuilder.Entity<Book>()
                .HasOne(b => b.Author)
                .WithMany(a => a.Books)
                .HasForeignKey(b => b.AuthorId);
        }
    }
}
