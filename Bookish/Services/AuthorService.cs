using Bookish.Repositories;
using Bookish.Models;
using Bookish.Models.Request;
using Bookish.Models.Database;

namespace Bookish.Services
{
    public interface IAuthorService
    {
        public List<Author> GetAllAuthors();
        public Author CreateAuthor(CreateAuthorRequest createAuthorRequest);
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

        public Author CreateAuthor(CreateAuthorRequest createAuthorRequest)
        {
    
            var insertedAuthor = _authors.CreateAuthor(
                new AuthorDbModel { AuthorName=createAuthorRequest.AuthorName,
                                AuthorPhotoUrl=createAuthorRequest.AuthorPhotoUrl}
            );
            return new Author(insertedAuthor);
            
            
        }
    }
}