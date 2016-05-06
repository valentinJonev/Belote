using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using Belot.Backend.ViewModels;

namespace Belot.Backend.Services
{
    public class GameValidationService
    {
        public Task ValidateForCreate(IPrincipal principal, GameCreateModel model)
        {
            throw new NotImplementedException();
        }

        public Task ValidateForDetails(IPrincipal principal, string userId, int id)
        {
            throw new NotImplementedException();
        }
    }
}
