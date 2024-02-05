namespace BookStoreApp.API.DTO.Book
{
    public class BookDetailsDTO : BaseDTO
    {
        public string Title { get; set; } = string.Empty;
        public int Year { get; set; } = 0;
        public string Isbn { get; set; } = string.Empty;
        public string Summary { get; set; } = string.Empty;
        public string Image { get; set; } = string.Empty;
        public decimal Price { get; set; } = 0;
        public int AuthorId { get; set; } = 0;
        public string AuthorName { get; set; } = string.Empty;
    }
}
