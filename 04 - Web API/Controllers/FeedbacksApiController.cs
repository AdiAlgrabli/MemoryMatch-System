using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JohnBryce
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]

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


        //[HttpPost]
        //[Route("feedbacks")]
        //public HttpResponseMessage AddFeedback(FeedbackModel feedbackModel)
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
        //        }

        //        FeedbackModel fm = feedbacksLogic.AddFeedback(feedbackModel);
        //        return Request.CreateResponse(HttpStatusCode.Created, fm);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }
        //}

        //[HttpGet]
        //[Route("all-feedbacks")]
        //public HttpResponseMessage GetAllFeedbacks()
        //{
        //    try
        //    {
        //        if (!ModelState.IsValid)
        //        {
        //            List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
        //            return Request.CreateResponse(HttpStatusCode.BadRequest, errorList);
        //        }

        //        List<FeedbackModel> feedbacks = feedbacksLogic.GetAllFeedbacks();
        //        return Request.CreateResponse(HttpStatusCode.OK, feedbacks);
        //    }
        //    catch (Exception ex)
        //    {
        //        return Request.CreateErrorResponse(HttpStatusCode.InternalServerError, ex);
        //    }
        //}

        //protected override void Dispose(bool disposing)
        //{
        //    base.Dispose(disposing);

        //    feedbacksLogic.Dispose();
        //}
    }
}
