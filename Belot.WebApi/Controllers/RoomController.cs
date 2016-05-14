using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Security.Principal;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using Belot.Backend.Services;
using Belot.Backend.ViewModels;
using Belot.WebApi.Common;

namespace Belot.WebApi.Controllers
{
    [RoutePrefix("rooms")]
    public class RoomController : BaseApiController
    {
        private RoomService service;

        public RoomController(RoomService service)
        {
            this.service = service;
        }

        [HttpPost, Route("")]
        public async Task<IHttpActionResult> Create(RoomViewModel model)
        {
            IPrincipal principal = RequestContext.Principal;
            int roomId = await this.service.CreateAsync(model, principal);
            return Ok(roomId);
        }

        [HttpGet, Route("{roomId:int}")]
        public async Task<IHttpActionResult> Details([FromUri][Required]int roomId)
        {
            RoomViewModel viewModel = await this.service.GetAsync(roomId);
            return Ok(viewModel);
        }

        [HttpPost, Route("{roomId:int}/join")]
        public async Task<IHttpActionResult> Join([FromUri][Required]int roomId)
        {
            IPrincipal principal = RequestContext.Principal;
            await this.service.Join(roomId, principal);
            return this.Ok();
        }
    }
}