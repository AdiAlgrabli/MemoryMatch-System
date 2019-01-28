using System;
using System.ComponentModel.DataAnnotations;

namespace JohnBryce
{
    public class FeedbackModel
    {
        public int id { get; set; }

        [Required(ErrorMessage = "This user is not registered!")]
        public int? userId { get; set; }

        public string username { get; set; }
        public DateTime? dateAdded { get; set; }

        [Required(ErrorMessage = "Missing Feedback.")]
        [MaxLength(400, ErrorMessage = "Max length is 400 chars.")]
        public string fbText { get; set; }

    }
}
