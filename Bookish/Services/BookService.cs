using Bookish.Repositories;
using Bookish.Models;
using Bookish.Models.Database;
using Bookish.Models.Request;

namespace Bookish.Services
{
    public interface IBookService
    {
        public List<Book> GetAllBooks();
        public Book CreateBook(CreateBookRequest createBookRequest);
    }
    
    public class BookService : IBookService
    {
        private IBookRepo _books;
        private IAuthorRepo _authors;
        
        public BookService(IBookRepo books, IAuthorRepo authors)
        {
            _books = books;
            _authors = authors;
        }

        public List<Book> GetAllBooks()
        {
            var dbBooks = _books.GetAllBooks();

            List<Book> result = new List<Book>();

            foreach(var dbBook in dbBooks)
            {
                result.Add(new Book(dbBook));
            }

            return result;
        }
        public Book CreateBook(CreateBookRequest createBookRequest)
        {
            var insertedAuthors = new List<AuthorDbModel>();
            if (createBookRequest.Authors !=null)
            {
                foreach (var author in createBookRequest.Authors)
                {
                    insertedAuthors.Add(
                        new AuthorDbModel
                        {
                            AuthorName = author,
                        }
                    );
                }
            }

            var insertedBook = _books.CreateBook(
                new BookDbModel
                {
                    Isbn =createBookRequest.Isbn,
                    Title =createBookRequest.Title,
                    Genre="",
                    Authors =  insertedAuthors,
                    YearOfPublication = null,
                    CoverPhotoUrl = createBookRequest.CoverPhotoUrl,
                }
            );
            return new Book(insertedBook);
        }
    }
}