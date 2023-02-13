using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace ApiCreateUserAndAssignPermissionsNotRole.Models
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
      : base(options)
        {

        }

        public virtual DbSet<LoginModel> Login { get; set; }
        public virtual DbSet<RegisterModel> Register { get; set; }

    }
}
