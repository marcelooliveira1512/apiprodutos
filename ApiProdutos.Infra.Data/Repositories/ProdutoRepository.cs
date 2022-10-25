using ApiProdutos.Domain.Contracts.Repositories;
using ApiProdutos.Domain.Entities;
using ApiProdutos.Infra.Data.Contexts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Infra.Data.Repositories
{
    public class ProdutoRepository : BaseRepository<Produto>, IProdutoRepository
    {
        public List<Produto> GetByNome(string nome)
        {
            using (var context = new SqlServerContext())
            {
                return context.Produto
                    .Where(p => p.Nome.Contains(nome))
                    .ToList();
            }
        }
    }
}
