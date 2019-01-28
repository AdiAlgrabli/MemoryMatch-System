using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace JohnBryce
{
    public class UserModel
    {        

        public int id { get; set; }

        [Required(ErrorMessage = "Missing Full Name")]
        [MaxLength(50, ErrorMessage = "Max length must be 50 chars.")]
        [RegularExpression("^[a-zA-Z -'.]*$", ErrorMessage = "Invalid Full Name.")]
        //[RegularExpression("^[a-zA-Z '-]{2,}(?: [a-zA-Z '-]{2,})+$", ErrorMessage = "Invalid Full Name.")]
        public string fullName { get; set; }

        [Required(ErrorMessage = "Missing Username.")]
        [MaxLength(20, ErrorMessage = "Max length must be 20 chars.")]
        [RegularExpression("^[a-zA-Z0-9 -_'.]*$", ErrorMessage = "Invalid Username.")]
        public string username { get; set; }

        [Required(ErrorMessage = "Missing Password.")]
        [MinLength(8, ErrorMessage = "Min length must be 8 chars.")]
        [MaxLength(20, ErrorMessage = "Max length must be 20 chars.")]
        [RegularExpression(@"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)[a-zA-Z\d]{8,}$", ErrorMessage = "Invalid password.")]
        public string password { get; set; }

        [EmailAddress(ErrorMessage = "Wrong Email Address Format.")]
        public string email { get; set; }

        // TODO - Delete it!!!!
        //[DataType(DataType.Date)]
        //[DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [CurrentDateAttribute(ErrorMessage = "Invalid Date!")]
        public DateTime? birthDate { get; set; }
    }
}
