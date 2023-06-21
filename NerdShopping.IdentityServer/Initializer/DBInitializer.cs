using IdentityModel;
using Microsoft.AspNetCore.Identity;
using NerdShopping.IdentityServer.Configuration;
using NerdShopping.IdentityServer.Model;
using NerdShopping.IdentityServer.Model.Context;
using System;
using System.Security.Claims;

namespace NerdShopping.IdentityServer.Initializer
{
    public class DBInitializer : IDBInitializer
    {
        private readonly MysqlContext _mysqlContext;
        private readonly UserManager<AppUser> _user;
        private readonly RoleManager<IdentityRole> _role;

        public DBInitializer(MysqlContext mysqlContext, UserManager<AppUser> user, RoleManager<IdentityRole> role)
        {
            _mysqlContext = mysqlContext;
            _user = user;
            _role = role;
        }

        public void Initialize()
        {
            if (_role.FindByNameAsync(IdentityConf.Adimn).Result != null)
            {
                return;
            }
            _role.CreateAsync(new IdentityRole(IdentityConf.Adimn)).GetAwaiter().GetResult();
            _role.CreateAsync(new IdentityRole(IdentityConf.Client)).GetAwaiter().GetResult();

            AppUser oAdmin =  new AppUser() 
            {
                UserName= "kendy",
                Email="eslei.elioterio@hotmail.com",
                EmailConfirmed  = true,
                PhoneNumber = "+55 (71) 991587055",
                Nome = "Kendy",
                SobreNome= "Elioterio"
            };
            _user.CreateAsync(oAdmin , "Elioterio@89").GetAwaiter().GetResult();
            _user.AddToRoleAsync(oAdmin, IdentityConf.Adimn).GetAwaiter().GetResult() ;

            var vAdminClains = _user.AddClaimsAsync(oAdmin, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{oAdmin.Nome} {oAdmin.SobreNome}"),
                new Claim(JwtClaimTypes.GivenName, oAdmin.Nome),
                new Claim(JwtClaimTypes.FamilyName,oAdmin.SobreNome),
                new Claim(JwtClaimTypes.Role, IdentityConf.Adimn)

            }).Result;

            AppUser oCliente = new AppUser()
            {
                UserName = "eslei.elioterio",
                Email = "eslei.elioterio@gmail.com",
                EmailConfirmed = true,
                PhoneNumber = "+55 (71) 991587055",
                Nome = "Eslei",
                SobreNome = "Elioterio"
            };
            _user.CreateAsync(oCliente, "Elioterio@89").GetAwaiter().GetResult();
            _user.AddToRoleAsync(oCliente, IdentityConf.Adimn).GetAwaiter().GetResult();

            var vClienteClains = _user.AddClaimsAsync(oCliente, new Claim[]
            {
                new Claim(JwtClaimTypes.Name, $"{oCliente.Nome} {oAdmin.SobreNome}"),
                new Claim(JwtClaimTypes.GivenName, oCliente.Nome),
                new Claim(JwtClaimTypes.FamilyName,oCliente.SobreNome),
                new Claim(JwtClaimTypes.Role, IdentityConf.Adimn)

            }).Result;
        }
    }
}
