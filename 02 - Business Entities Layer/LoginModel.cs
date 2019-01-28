using System.ComponentModel.DataAnnotations;

namespace JohnBryce
{
    public class LoginModel
    {

        public int userId { get; set; }

        [Required(ErrorMessage = "Missing Username.")]
        [MaxLength(20, ErrorMessage = "Max length must be 20 chars.")]
        [RegularExpression("^[a-zA-Z0-9-_'.]+$", ErrorMessage = "Invalid Username.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Missing Password.")]
        [MinLength(8, ErrorMessage = "Min length must be 8 chars.")]
        [MaxLength(20, ErrorMessage = "Max length must be 20 chars.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Invalid password.")]
        public string password { get; set; }
    }
}
