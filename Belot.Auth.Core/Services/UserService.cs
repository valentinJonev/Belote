using System.Threading.Tasks;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Belot.Auth.Core.Context;
using Belot.Auth.Core.ViewModels;

namespace Belot.Auth.Core.Services
{
    public class UserService
    {
        private UserManager<IdentityUser> userManager;

        public UserService(AuthContext context)
        {
            userManager = new UserManager<IdentityUser>(new UserStore<IdentityUser>(context));
        }

        public Task<IdentityResult> CreateAsync(UserCreateModel model)
        {
            var user = new IdentityUser()
            {
                UserName = model.Username
            };

            return userManager.CreateAsync(user, model.Password);
        }
    }
}
