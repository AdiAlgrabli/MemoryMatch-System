using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JohnBryce
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]

    public class LoginController : ApiController
    {
        private LoginLogic loginLogic = new LoginLogic();

        [HttpPost]
        [Route("login")]
        public IHttpActionResult Login(LoginModel loginModel)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Content(HttpStatusCode.BadRequest, errorList);
                }

                LoginModel returnedLoginModel = loginLogic.Login(loginModel.username, loginModel.password);

                // If the user doesn't exist in DB
                if (returnedLoginModel == null)
                {
                    string error = "Error Message: This user doesn't exist.";
                    return Content(HttpStatusCode.NotFound, error);
                }

                return Ok(returnedLoginModel);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing);

            loginLogic.Dispose();
        }
    }
}
