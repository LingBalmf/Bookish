using Bookish.Models.Database;

namespace Bookish.Models
{
    public class Book
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public string? Genre { get; set; }
        public List<Author>? Authors { get; set; }
        public int? YearOfPublication { get; set; }
        public string? CoverPhotoUrl { get; set; }

        public Book(BookDbModel bookDbModel)
        {
            Isbn = bookDbModel.Isbn;
            Title = bookDbModel.Title;
            Genre = bookDbModel.Genre;
            Authors = bookDbModel.Authors?.Select(a => new Author(a)).ToList();
            CoverPhotoUrl = bookDbModel.CoverPhotoUrl;
            YearOfPublication = bookDbModel.YearOfPublication;
        }
    }
}