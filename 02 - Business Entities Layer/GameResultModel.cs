using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class GameResultModel
    {
        public int id { get; set; }
        public int? userId { get; set; }

        public string username { get; set; }
        public string fullName { get; set; }

        [CurrentDateAttribute(ErrorMessage = "Invalid Date!")]
        public DateTime? dateAdded { get; set; }
        
        // TODO - Check if RegEx validation is needed
        [RegularExpression(@"[0-2][0-3]\:[0-5][0-9]\:[0-5][0-9]", ErrorMessage = "Invalid time format.")]
        public TimeSpan? timeSpan { get; set; }

        public int? steps { get; set; }
    }
}
