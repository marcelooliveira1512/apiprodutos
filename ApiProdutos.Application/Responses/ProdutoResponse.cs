namespace ApiProdutos.Application.Responses
{
    public class ProdutoResponse
    {
        public Guid? Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int? Quantidade { get; set; }
        public decimal? Total { get; set; }
        public DateTime? DataCadastro { get; set; }
        public CategoriaResponse? Categoria { get; set; }
    }

    public class CategoriaResponse
    {
        public int? Id { get; set; }
        public string? Nome { get; set; }
    }
}



