using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JohnBryce
{
    public class ImagesLogic : BaseLogic
    {
        public List<ImageModel> GetAllImages()
        {
            var query = from img in DB.Images
                        select new ImageModel
                        {
                            id = img.ImageID,
                            imageName = img.ImageName,
                            imageType = img.ImageType
                        };

            return query.ToList();
        }
    }
}
