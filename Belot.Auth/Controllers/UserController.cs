using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;
using System.Web.Http;
using Microsoft.AspNet.Identity;
using Belot.Auth.Core.Context;
using Belot.Auth.Core.Services;
using Belot.Auth.Core.ViewModels;

namespace Belot.Auth.Controller
{
    [RoutePrefix("api/users")]
    [Authorize]
    public class UserController : ApiController
    {
        private UserService userService;
        private UserValidationService validationService;

        public UserController()
        {
            var context = new AuthContext();

            this.userService = new UserService(context);
            this.validationService = new UserValidationService(context); ;
        }

        [AllowAnonymous]
        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Register(UserCreateModel model)
        {
            if (await validationService.CheckExistingUsernameAsync(RequestContext.Principal, model.Username))
            {
                return Content(HttpStatusCode.Conflict,
                    new
                    {
                        Message = "Operation is impossible",
                        Errors = new List<string> { "User with this name already exists" }
                    });
            }

            IdentityResult result = await userService.CreateAsync(model);
            if (result.Errors.Count() > 0)
            {
                var badRequestError = new BadRequestError();
                badRequestError.AddErrors(result.Errors);

                return Content(HttpStatusCode.BadRequest,
                    new {
                        Message = "Bad Request",
                        ModelErrors = new Dictionary<string, BadRequestError>() { { "", badRequestError } },
                        Errors = new List<string>()
                    });
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        public class BadRequestError
        {
            public BadRequestError()
            {
                Errors = new List<string>();
                Exceptions = new List<string>();
            }

            public IList<string> Errors { get; private set; }

            public IList<string> Exceptions { get; private set; }

            public void AddError(string error)
            {
                Errors.Add(error);
            }

            public void AddErrors(IEnumerable<string> errors)
            {
                foreach (var err in errors)
                {
                    Errors.Add(err);
                }
            }

            public void AddException(string exceptionMessage)
            {
                Exceptions.Add(exceptionMessage);
            }
        }
    }
}