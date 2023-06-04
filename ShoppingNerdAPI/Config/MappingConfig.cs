using AutoMapper;
using ShoppingNerdAPI.Data.ValueObjects;
using ShoppingNerdAPI.Model.Base;

namespace ShoppingNerdAPI.Config
{
    public class MappingConfig
    {
        public static MapperConfiguration RegistroMaps() 
        {
            var oMappingConfig =  new MapperConfiguration(config=>
            {
                config.CreateMap<ProdutoVO, Produto>();
                config.CreateMap<Produto, ProdutoVO > ();
            });

            return oMappingConfig;
        }
    }
}
