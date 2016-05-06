using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Belot.Backend.ViewModels;

namespace Belot.Backend.Services
{
    public class GameService
    {
        public Task<int> CreateAsync(GameCreateModel model, IPrincipal principal)
        {
            throw new NotImplementedException();
        }

        public Task<GameDetailsModel> GetAsync(int id, string userId)
        {
            throw new NotImplementedException();
        }
    }
}
