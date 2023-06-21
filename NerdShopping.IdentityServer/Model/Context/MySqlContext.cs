using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace NerdShopping.IdentityServer.Model.Context
{
    public class MysqlContext : IdentityDbContext<AppUser>
    {

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options) { }
        
    }
}
