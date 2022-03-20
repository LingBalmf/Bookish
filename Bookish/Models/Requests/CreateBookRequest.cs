namespace Bookish.Models.Request
{
    public class CreateBookRequest
    {
        public string? Isbn { get; set; }
        public string? Title { get; set; }
        public List<string>? Authors { get; set; }
        public string? CoverPhotoUrl { get; set; }

    }
}