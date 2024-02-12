using System.ComponentModel.DataAnnotations;

namespace BookStoreApp.API.DTO.User
{
    public class UserDto : LoginUserDto
    {
        [Required]
        [MaxLength(50, ErrorMessage = "First Name cannot exceed 50 characters")]
        [Display(Name = "First Name")]
        public string FirstName { get; set; } = string.Empty;

        [Required]
        [Display(Name = "Last Name")]
        [MaxLength(50, ErrorMessage = "Last Name cannot exceed 50 characters")]
        public string LastNamr { get; set; } = string.Empty;

        public string Role { get; set; } = string.Empty;
    }
}