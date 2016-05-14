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

        public GameController(GameService gameService)
        {
            this.gameService = gameService;
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create(GameCreateModel model)
        {
            IPrincipal principal = RequestContext.Principal;

            int gameId = await gameService.CreateAsync(model, principal);

            return Ok(gameId);
        }

        [HttpGet, Route("{id:int}")]
        public async Task<IHttpActionResult> Details(int id)
        {
            IPrincipal principal = RequestContext.Principal;

            GameDetailsModel model = await this.gameService.GetAsync(id);

            return Ok(model);
        }

        [HttpPost, Route("{id:int}/playCard")]
        public async Task<IHttpActionResult> PlayCard(int cardId)
        {
            IPrincipal principal = RequestContext.Principal;

            await this.gameService.PlayCard(cardId, principal);

            return this.Ok();
        }
    }
}
