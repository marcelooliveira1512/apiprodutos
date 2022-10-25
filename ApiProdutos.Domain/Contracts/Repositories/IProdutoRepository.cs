using ApiProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Domain.Contracts.Repositories
{
    public interface IProdutoRepository : IBaseRepository<Produto>
    {
        List<Produto> GetByNome(string nome);
    }
}
