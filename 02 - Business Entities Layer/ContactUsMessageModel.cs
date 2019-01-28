using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class ContactUsMessageModel
    {
        public int id { get; set; }

        // TODO - maybe change the format it's being saved as in DB
        [CurrentDateAttribute(ErrorMessage = "Invalid Date!")]
        public DateTime? dateAdded { get; set; }

        // TODO - Add in angular select box with set numbers
        [RegularExpression(@"^05[02345678][1-9]\d{6}$|^0[23489][1-9]\d{6}$", ErrorMessage = "Invalid phone number")]
        public string phone { get; set; }

        [EmailAddress(ErrorMessage = "Invalid Email Address.")]
        public string email { get; set; }

        [Required(ErrorMessage = "Message content is missing")]
        [MaxLength(400, ErrorMessage = "Max length is 400 chars")]
        public string msgContent { get; set; }
    }
}
