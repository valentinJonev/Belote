using System.Security.Principal;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Belot.Auth.Core.Context;

namespace Belot.Auth.Core.Services
{
    public class UserValidationService
    {
        private AuthContext context;
        private UserManager<IdentityUser> userManager;

        public UserValidationService(AuthContext context)
        {
            this.context = context;
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        }

        public async Task<bool> CheckExistingUsernameAsync(IPrincipal currentPrincipal, string username)
        {
            string currentUsername = currentPrincipal.Identity.Name;
            IdentityUser user = await userManager.FindByNameAsync(username);

            return user != null;
        }
    }
}
