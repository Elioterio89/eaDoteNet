using Duende.IdentityServer.Extensions;
using Duende.IdentityServer.Models;
using Duende.IdentityServer.Services;
using IdentityModel;
using Microsoft.AspNetCore.Identity;
using NerdShopping.IdentityServer.Model;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace NerdShopping.IdentityServer.Services
{
    public class ProfileService : IProfileService
    {

        private readonly UserManager<AppUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly IUserClaimsPrincipalFactory<AppUser> _userClaims;

        public ProfileService(UserManager<AppUser> userManager, RoleManager<IdentityRole> roleManager, IUserClaimsPrincipalFactory<AppUser> userClaims)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _userClaims = userClaims;
        }

        public async Task GetProfileDataAsync(ProfileDataRequestContext context)
        {
            string id = context.Subject.GetSubjectId();
            AppUser user = await _userManager.FindByIdAsync(id);
            ClaimsPrincipal userClaims = await _userClaims.CreateAsync(user);
            List<Claim> claims = userClaims.Claims.ToList();
            claims.Add(new Claim(JwtClaimTypes.FamilyName, user.SobreNome));
            claims.Add(new Claim(JwtClaimTypes.GivenName, user.Nome));

            if (_userManager.SupportsUserRole)
            {
                IList<string> roles = await _userManager.GetRolesAsync(user);
                foreach (string role in roles )
                {
                    claims.Add(new Claim(JwtClaimTypes.Role, role));
                    if (_roleManager.SupportsRoleClaims)
                    {
                        IdentityRole identityRole = await _roleManager.FindByNameAsync(role);
                        if (identityRole != null) 
                        {
                            claims.AddRange(await _roleManager.GetClaimsAsync(identityRole));
                        } 

                    }

                }
            }
            context.IssuedClaims = claims;
        }

        public async Task IsActiveAsync(IsActiveContext context)
        {

            string id = context.Subject.GetSubjectId();
            AppUser user = await _userManager.FindByIdAsync(id);
            context.IsActive = user != null;
        }
    }
}
