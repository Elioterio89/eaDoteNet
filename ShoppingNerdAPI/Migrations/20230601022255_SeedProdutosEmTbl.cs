using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace ShoppingNerdAPI.Migrations
{
    /// <inheritdoc />
    public partial class SeedProdutosEmTbl : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.InsertData(
                table: "Produto",
                columns: new[] { "Id", "CategoriaNome", "Descricao", "ImageUrl", "Nome", "Preco" },
                values: new object[,]
                {
                    { 1L, "Vestimenta", "Calça Slim", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.aswracing.com.br%2Fcalca-asw-image-minimal-23-a1048723-p4013646&psig=AOvVaw1isNPh-QwGdSv-p919sBfC&ust=1685672108553000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCIiL64qAof8CFQAAAAAdAAAAABAE", "Calça", 69.2m },
                    { 3L, "Esporte", "Bola Futebol", "https://www.google.com/url?sa=i&url=https%3A%2F%2Focfc.com.br%2Fproduto%2Fbola-futebol-adidas-uefa-real-madrid-finale-2016-capitano-campo%2F&psig=AOvVaw0c_HhuDyMrc8Ayh88V929k&ust=1685672359619000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCMj4lIOBof8CFQAAAAAdAAAAABAJ", "Bola", 69.2m },
                    { 4L, "Esoporte", "Camisa Boston Celtics", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.aswracing.com.br%2Fcalca-asw-image-minimal-23-a1048723-p4013646&psig=AOvVaw1isNPh-QwGdSv-p919sBfC&ust=1685672108553000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCIiL64qAof8CFQAAAAAdAAAAABAE", "Camisa Boston", 169.2m },
                    { 5L, "Esporte", "Camisa N1 Ec Vitoria", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fecvitoria.com.br%2F&psig=AOvVaw18GzKbptFY0jKW12awdw5D&ust=1685672284695000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCMiXzd-Aof8CFQAAAAAdAAAAABAE", "Camisa Vitoria", 269.2m },
                    { 6L, "Banho", "Tolha de banho", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.zelo.com.br%2Fkit-toalha-banho-e-toalha-rosto-zelo-classic-gramatura-400g-m-fendi-p1000952&psig=AOvVaw0nGAUY5FxvJk9eWeaPRg9O&ust=1685672244467000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCIijmsyAof8CFQAAAAAdAAAAABAE", "Toalha", 29.2m },
                    { 7L, "Vestimenta", "Cueca Box", "https://www.google.com/url?sa=i&url=https%3A%2F%2Fwww.bigburgplussize.com.br%2Fcueca-boxer-algodao-max-pr-14797-rim-702-p53921&psig=AOvVaw1aKrmaFO9njjVfH3-DoAj7&ust=1685672201709000&source=images&cd=vfe&ved=0CBEQjRxqFwoTCOiy87eAof8CFQAAAAAdAAAAABAE", "Cueca", 9.2m }
                });
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 1L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 3L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 4L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 5L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 6L);

            migrationBuilder.DeleteData(
                table: "Produto",
                keyColumn: "Id",
                keyValue: 7L);
        }
    }
}
