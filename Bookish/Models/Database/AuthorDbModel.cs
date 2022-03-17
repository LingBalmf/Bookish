namespace Bookish.Models.Database
{
    public class AuthorDbModel
    {
        public int? Id { get; set; }
        public string? AuthorName { get; set; }
        public string? AuthorPhotoUrl { get; set; }
        public List<BookDbModel>? Books { get; set; }
    }
}