using Bookish.Models.Database;
namespace Bookish.Models
{
    public class Author
    {
        public string? AuthorName { get; set; }

        public string? AuthorPhotoUrl { get; set; }

        public Author() {}

        public Author(AuthorDbModel authorDbModel)
        {
            AuthorName = authorDbModel.AuthorName;
            AuthorPhotoUrl = authorDbModel.AuthorPhotoUrl;
        }
    }
}