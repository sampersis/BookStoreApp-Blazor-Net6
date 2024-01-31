using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.DTO.Author
{
    public class AuthourDTO
    {
        [Required, StringLength(50)]
        public string FirstName { get; set; } = string.Empty;
        [Required, StringLength(50)]
        public string LastName { get; set; } = string.Empty;
        [StringLength(250)]
        public string Bio { get; set; } = string.Empty;
    }
}
