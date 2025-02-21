using System.ComponentModel.DataAnnotations;

namespace WebApplication3.DTO
{
    using System.ComponentModel.DataAnnotations;

    public class LoginDTO
    {
        [Required]
        [EmailAddress(ErrorMessage = "Invalid email format.")]
        public string Email { get; set; }

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters long.")]
        [RegularExpression(@"^(?=.*[A-Z])(?=.*[a-z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$",
            ErrorMessage = "Password must have at least 8 characters, one uppercase, one lowercase, one digit, and one special character.")]
        public string Password { get; set; }
    }

}
