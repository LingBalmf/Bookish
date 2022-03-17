using Bookish.Repositories;
using Bookish.Models;

namespace Bookish.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAllAuthors();
    }
    
    public class AuthorService : IAuthorService
    {
        private IAuthorRepo _authors;

        public AuthorService(IAuthorRepo authors)
        {
            _authors = authors;
        }

        public List<Author> GetAllAuthors()
        {
            var dbAuthors = _authors.GetAllAuthors();

            List<Author> result = new List<Author>();

            foreach(var dbAuthor in dbAuthors)
            {
                result.Add(new Author(dbAuthor));
            }

            return result;
        }
    }
}