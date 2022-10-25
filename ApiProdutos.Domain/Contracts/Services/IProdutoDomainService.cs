using ApiProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Domain.Contracts.Services
{
    public interface IProdutoDomainService : IBaseDomainService<Produto>
    {
        List<Produto> ObterPorNome(string nome);
    }
}
