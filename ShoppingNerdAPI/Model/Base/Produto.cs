using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace ShoppingNerdAPI.Model.Base
{

    [Table("Produto")]
    public class Produto: BaseEntity
    {
        [Column("Nome")]
        [Required]
        [StringLength(150)]
        public string Nome { get; set; }

        [Column("Preco")]
        [Required]
        [Range(1,10000)]
        public decimal Preco { get; set; }

        [Column("Descricao")]
        [StringLength(500)]
        public string Descricao { get; set; }

        [Column("CategoriaNome")]
        [StringLength(50)]
        public string Categoria { get; set; }

        [Column("ImageUrl")]
        [Required]
        [StringLength(500)]
        public string ImageUrl { get; set; }
    }
}
