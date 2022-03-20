using Bookish.Models.Database;
using Microsoft.EntityFrameworkCore;

namespace Bookish.Repositories
{
    public interface IAuthorRepo
    {
        public List<AuthorDbModel> GetAllAuthors();
        public AuthorDbModel CreateAuthor(AuthorDbModel newAuthor);
    }
    
    public class AuthorRepo : IAuthorRepo
    {
        private BookishContext context = new BookishContext();

        public List<AuthorDbModel> GetAllAuthors()
        {
            return context
                .Authors
                .ToList();
        }
        public AuthorDbModel CreateAuthor(AuthorDbModel newAuthor)
        {
            var insertedAuthorEntry = context.Authors.Add(newAuthor);
            context.SaveChanges();
            return insertedAuthorEntry.Entity;
        }
    }
}