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
        public async Task<IHttpActionResult> Create()
        {
            IPrincipal principal = RequestContext.Principal;
            string roomId = await this.service.CreateAsync(principal);
            return Ok(roomId);
        }

        [HttpGet, Route("{roomId:string}")]
        public async Task<IHttpActionResult> Details([FromUri][Required]string roomId)
        {
            RoomViewModel viewModel = await this.service.GetAsync(roomId);
            return Ok(viewModel);
        }

        [HttpPost, Route("{roomId:string}/join")]
        public void Join([FromUri][Required]string roomId)
        {
            IPrincipal principal = RequestContext.Principal;
            this.service.Join(roomId, principal);
        }
    }
}