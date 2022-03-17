using Bookish.Models.Database;
using Bookish.Models;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public interface IBookRepo
    {
        public List<BookDbModel> GetAllBooks();
        public BookDbModel CreateBook(BookDbModel newBook);
    }
    
    public class BookRepo : IBookRepo
    {
        private BookishContext context = new BookishContext();

        public List<BookDbModel> GetAllBooks()
        {
            return context
                .Books
                .Include(b => b.Authors)
                .ToList();
        }

        public BookDbModel CreateBook(BookDbModel newBook)
        {
            var insertedBookEntry = context.Books.Add(newBook);
            context.SaveChanges();
            return insertedBookEntry.Entity;

        }
    }
}