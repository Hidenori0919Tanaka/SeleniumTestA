using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Security.Claims;
using System.Threading.Tasks;

namespace UnitTest_Sample.Models
{
    public class ApplicationUser : IdentityUser
    {
        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // authenticationType が CookieAuthenticationOptions.AuthenticationType で定義されているものと一致している必要があります
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // ここにカスタム ユーザー クレームを追加します
            return userIdentity;
        }
    }
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext()
            : base("HTDB", throwIfV1Schema: false)
        {
            //Configuration.ProxyCreationEnabled = false;
            //this.Configuration.LazyLoadingEnabled = false;

            //Database.SetInitializer<ApplicationDbContext>(null);
        }

        public static ApplicationDbContext Create()
        {
            return new ApplicationDbContext();
        }
        public DbSet<Fa> Fas { get; set; }
        public DbSet<Sec> Secs { get; set; }
    }

    //public class BasicContext : ApplicationDbContext
    //{
    //    public virtual DbSet<Fa> Fas { get; set; }
    //    public virtual DbSet<Sec> Secs { get; set; }
    //}
}