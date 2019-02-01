using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JohnBryce
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]

    public class MessagesApiController : ApiController
    {
        private MessagesLogic messagesLogic = new MessagesLogic();

        [HttpPost]
        [Route("contact-us")]
        public IHttpActionResult AddMessage(ContactUsMessageModel messageModel)
        {
            try
            {
                // if bad information was sent:
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Content(HttpStatusCode.BadRequest, errorList);
                }
                ContactUsMessageModel mm = messagesLogic.AddMessage(messageModel);
                return Content(HttpStatusCode.Created, mm);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            messagesLogic.Dispose();
        }
    }

   
}
