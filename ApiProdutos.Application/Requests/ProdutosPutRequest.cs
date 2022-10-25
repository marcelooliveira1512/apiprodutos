using System.ComponentModel.DataAnnotations;

namespace ApiProdutos.Application.Requests
{
    public class ProdutosPutRequest
    {
        [Required(ErrorMessage = "Por favor, informe o id do produto.")]
        public Guid? IdProduto { get; set; }

        [Required(ErrorMessage = "Por favor, informe o nome do produto.")]
        public string? Nome { get; set; }

        [Required(ErrorMessage = "Por favor, informe a descrição do produto.")]
        public string? Descricao { get; set; }

        [Required(ErrorMessage = "Por favor, informe o preço do produto.")]
        public decimal? Preco { get; set; }

        [Required(ErrorMessage = "Por favor, informe a quantidade do produto.")]
        public int? Quantidade { get; set; }

        [Required(ErrorMessage = "Por favor, informe a categoria do produto.")]
        public int? Categoria { get; set; }
    }
}



