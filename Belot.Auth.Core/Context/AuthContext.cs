using System.Data.Entity;
using Microsoft.AspNet.Identity.EntityFramework;

namespace Belot.Auth.Core.Context
{
    public class AuthContext : IdentityDbContext<IdentityUser>
    {
        public AuthContext()
            : this("AuthContext")
        {
        }

        public AuthContext(string connectionString)
            : base(connectionString)
        {
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
