using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.DTO.User
{
    public class LoginUserDto
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid Email Address")]
        [Display(Name = "Email Address")]
        [MaxLength(50, ErrorMessage = "Email address cannot exceed 50 characters")]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Password { get; set; } = string.Empty;
    }
}