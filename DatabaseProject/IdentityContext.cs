using Domain;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Database
{
    public class IdentityContext: IdentityDbContext<User>
    {
      public IdentityContext(DbContextOptions<IdentityContext> options)
    : base(options)
        {
            Database.Migrate();
        }

    }
}
