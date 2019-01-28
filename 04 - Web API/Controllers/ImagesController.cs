using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JohnBryce
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]

    public class ImagesController : ApiController
    {
        public ImagesLogic imagesLogic = new ImagesLogic();

        [HttpGet]
        [Route("game")]
        public IHttpActionResult GetAllImages()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Content(HttpStatusCode.BadRequest, errorList);
                }

                List<ImageModel> images = imagesLogic.GetAllImages();
                return Ok(images);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            imagesLogic.Dispose();
        }
    }   
}
