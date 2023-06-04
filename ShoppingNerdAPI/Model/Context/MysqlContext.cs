using Microsoft.EntityFrameworkCore;
using ShoppingNerdAPI.Model.Base;

namespace ShoppingNerdAPI.Model.Context
{
    public class MysqlContext : DbContext
    {
        public MysqlContext() { }

        public MysqlContext(DbContextOptions<MysqlContext> options) : base(options) { }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseMySql("Server=localhost;Database=shoppingnerd;Uid=root;Pwd=1234;", new MySqlServerVersion(new Version(8, 0)));
        }

        public DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder pModelBuilder)
        {
            pModelBuilder.Entity<Produto>().HasData(
                new Produto
                {
                    Id = 1,
                    Nome = "Calça",
                    Categoria = "Vestimenta",
                    Descricao = "Calça Slim",
                    Preco = new decimal( 69.2),
                    ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.aswracing.com.br%2Fcalca-asw-image-minimal-23-a1048723-p4013646&psig=AOvVaw1isNPh-QwGdSv-p919sBfC&ust=1685672108553000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCIiL64qAof8CFQAAAAAdAAAAABAE",
                }
            );
            pModelBuilder.Entity<Produto>().HasData(
               new Produto
               {
                   Id = 3,
                   Nome = "Bola",
                   Categoria = "Esporte",
                   Descricao = "Bola Futebol",
                   Preco = new decimal(69.2),
                   ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Focfc.com.br%2Fproduto%2Fbola-futebol-adidas-uefa-real-madrid-finale-2016-capitano-campo%2F&psig=AOvVaw0c_HhuDyMrc8Ayh88V929k&ust=1685672359619000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCMj4lIOBof8CFQAAAAAdAAAAABAJ",
               }
           );
            pModelBuilder.Entity<Produto>().HasData(
               new Produto
               {
                   Id = 4,
                   Nome = "Camisa Boston",
                   Categoria = "Esoporte",
                   Descricao = "Camisa Boston Celtics",
                   Preco = new decimal(169.2),
                   ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.aswracing.com.br%2Fcalca-asw-image-minimal-23-a1048723-p4013646&psig=AOvVaw1isNPh-QwGdSv-p919sBfC&ust=1685672108553000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCIiL64qAof8CFQAAAAAdAAAAABAE",
               }
           );
            pModelBuilder.Entity<Produto>().HasData(
               new Produto
               {
                   Id = 5,
                   Nome = "Camisa Vitoria",
                   Categoria = "Esporte",
                   Descricao = "Camisa N1 Ec Vitoria",
                   Preco = new decimal(269.2),
                   ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fecvitoria.com.br%2F&psig=AOvVaw18GzKbptFY0jKW12awdw5D&ust=1685672284695000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCMiXzd-Aof8CFQAAAAAdAAAAABAE",
               }
           );
            pModelBuilder.Entity<Produto>().HasData(
               new Produto
               {
                   Id = 6,
                   Nome = "Toalha",
                   Categoria = "Banho",
                   Descricao = "Tolha de banho",
                   Preco = new decimal(29.2),
                   ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.zelo.com.br%2Fkit-toalha-banho-e-toalha-rosto-zelo-classic-gramatura-400g-m-fendi-p1000952&psig=AOvVaw0nGAUY5FxvJk9eWeaPRg9O&ust=1685672244467000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCIijmsyAof8CFQAAAAAdAAAAABAE",
               }
           );
            pModelBuilder.Entity<Produto>().HasData(
               new Produto
               {
                   Id = 7,
                   Nome = "Cueca",
                   Categoria = "Vestimenta",
                   Descricao = "Cueca Box",
                   Preco = new decimal(09.2),
                   ImageUrl = "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.bigburgplussize.com.br%2Fcueca-boxer-algodao-max-pr-14797-rim-702-p53921&psig=AOvVaw1aKrmaFO9njjVfH3-DoAj7&ust=1685672201709000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCOiy87eAof8CFQAAAAAdAAAAABAE",
               }
           );
        }
    }
}
