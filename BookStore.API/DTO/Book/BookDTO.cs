using BookStoreApp.API.Data;

namespace BookStoreApp.API.DTO.Book
{
    public class BookReadOnlyDTO : BaseDTO
    {
        public string Title { get; set; } = string.Empty;

        public string Image { get; set; } = string.Empty;

        public decimal Price { get; set; } = 0;

        public int AuthId { get; set; } = 0;

        public string AuthorName { get; set; } = string.Empty;
    }
}
