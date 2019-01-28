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

    public class GameResultsApiController : ApiController
    {
        GameResultsLogic gameResultsLogic = new GameResultsLogic();

        [HttpPost]
        [Route("game-results")]
        public IHttpActionResult AddGameResult(GameResultModel gameResultModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Content(HttpStatusCode.BadRequest, errorList);
                }

                GameResultModel grm = gameResultsLogic.AddResult(gameResultModel);
                return Content(HttpStatusCode.Created, grm);
            }
            catch(Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        [HttpGet]
        [Route("game-results")]
        public IHttpActionResult GetAllResults(GameResultModel gameResultModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Content(HttpStatusCode.BadRequest, errorList);
                }

                List<GameResultModel> grm = gameResultsLogic.GetAllResults();
                return Ok(grm);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            gameResultsLogic.Dispose();
        }
    }
}
