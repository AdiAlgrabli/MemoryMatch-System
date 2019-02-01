using System;
using System.Collections.Generic;
using System.Net;
using System.Web.Http;
using System.Web.Http.Cors;

namespace JohnBryce
{
    [EnableCors("*", "*", "*")]
    [RoutePrefix("api")]

    public class UsersApiController : ApiController
    {
        private UsersLogic usersLogic = new UsersLogic();
        private LoginLogic loginLogic = new LoginLogic();

        [HttpPost]
        [Route("registration")]
        public IHttpActionResult AddUser(UserModel userModel)
        {
            try
            {
                // if bad information was sent:
                if (!ModelState.IsValid)
                {
                    List<PropErrors> errorList = ErrorExtractor.ExtractErrors(ModelState);
                    return Content(HttpStatusCode.BadRequest, errorList);
                }                

                // if an existed user tries to register (username & password): 
                if (loginLogic.Login(userModel.username, userModel.password) != null)
                {
                    string error = "This user already exists in DB.";
                    return Content(HttpStatusCode.Conflict, error);
                }

                UserModel um = usersLogic.AddUser(userModel);
                ModelState.Clear(); //? check it
                return Content(HttpStatusCode.Created, um);
            }
            catch (Exception ex)
            {
                return InternalServerError(ex);
            }
        }

        protected override void Dispose(bool disposing)
        {
            base.Dispose(disposing); 

            usersLogic.Dispose();
        }
    }
}
