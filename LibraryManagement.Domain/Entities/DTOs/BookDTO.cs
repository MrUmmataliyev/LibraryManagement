namespace LibraryManagement.Domain.Entities.DTOs
{
    public class BookDTO
    {
        public string BookName { get; set; }
        public string AuthorName { get; set; }
        public string Category { get; set; }
        public string BookShelfSector { get; set; }
        public int PublishedYear { get; set; }
    }
}
