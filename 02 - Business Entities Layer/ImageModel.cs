using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;


namespace JohnBryce
{
    public class ImageModel
    {
        public int id { get; set; }
        public string imageName { get; set; }

        // The image types in DB are 'card' (card images) OR 'background' (background images)
        [RegularExpression("^\b(card|background)\b$")]
        public string imageType { get; set; }

    }
}
