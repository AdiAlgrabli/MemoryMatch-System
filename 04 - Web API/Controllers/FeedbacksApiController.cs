using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JohnBryce
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]
    // comment
    public class FeedbacksApiController : ApiController
    {
        private FeedbacksLogic feedbacksLogic = new FeedbacksLogic();
        private LoginLogic loginLogic = new LoginLogic();      

        [HttpPost]
        [Route("feedbacks")]
        public IHttpActionResult AddFeedback(FeedbackModel feedbackModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Content(HttpStatusCode.BadRequest, errorList);
                }

                FeedbackModel fm = feedbacksLogic.AddFeedback(feedbackModel);
                return Content(HttpStatusCode.Created, fm);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("all-feedbacks")]
        public IHttpActionResult GetAllFeedbacks()
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Content(HttpStatusCode.BadRequest, errorList);
                }

                List<FeedbackModel> feedbacks = feedbacksLogic.GetAllFeedbacks();
                return Ok(feedbacks);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            feedbacksLogic.Dispose();
        }
    }
}
