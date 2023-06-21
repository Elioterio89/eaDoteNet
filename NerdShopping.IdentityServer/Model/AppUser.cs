using Microsoft.AspNetCore.Identity;

namespace NerdShopping.IdentityServer.Model
{
    public class AppUser : IdentityUser
    {
        public string Nome { get; set; }
        public string SobreNome { get; set; }
    }
}
