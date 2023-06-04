namespace ShoppingNerd.Web.Models
{
    public class Produto
    {
        public long Id { get; set; }
        public string Nome { get; set; }
        public decimal Preco { get; set; }
        public string Descricao { get; set; }
        public string Categoria { get; set; }
        public string ImageUrl { get; set; }
    }
}
