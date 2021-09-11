using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace TamoodlApi.Data.Contexts
{
    public class UsersDbContext : IdentityDbContext<IdentityUser>
    {
        public UsersDbContext(DbContextOptions<UsersDbContext> options)
            :
            base(options)
        {
            
        }
    }
}