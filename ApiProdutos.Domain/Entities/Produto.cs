using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Domain.Entities
{
    public class Produto
    {
        #region Propriedades

        public Guid Id { get; set; }
        public string? Nome { get; set; }
        public string? Descricao { get; set; }
        public decimal Preco { get; set; }
        public int Quantidade { get; set; }
        public DateTime? DataCadastro { get; set; }
        public Categoria Categoria { get; set; }

        #endregion
    }
}
