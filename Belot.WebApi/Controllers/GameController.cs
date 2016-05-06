using System.ComponentModel.DataAnnotations;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web.Http;
using Belot.Backend.Services;
using Belot.Backend.ViewModels;
using Belot.WebApi.Common;

namespace Belot.WebApi.Controllers
{
    [RoutePrefix("games")]
    public class GameController : BaseApiController
    {
        private GameService gameService;
        private GameValidationService validationService;

        public GameController(GameService gameService, GameValidationService validationService)
        {
            this.gameService = gameService;
            this.validationService = validationService;
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create(GameCreateModel model)
        {
            IPrincipal principal = RequestContext.Principal;
            await validationService.ValidateForCreate(principal, model);

            int gameId = await gameService.CreateAsync(model, principal);

            return Ok(gameId);
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IHttpActionResult> Details(int id, [FromUri][Required]string user_id)
        {
            string userId = user_id;

            IPrincipal principal = RequestContext.Principal;
            await validationService.ValidateForDetails(principal, userId, id);

            GameDetailsModel model = await gameService.GetAsync(id, userId);

            return Ok(model);
        }
    }
}
