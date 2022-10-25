using ApiProdutos.Domain.Contracts.Repositories;
using ApiProdutos.Domain.Contracts.Services;
using ApiProdutos.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Domain.Services
{
    public class ProdutoDomainService : BaseDomainService<Produto>, IProdutoDomainService
    {
        private readonly IProdutoRepository _produtoRepository;

        public ProdutoDomainService(IProdutoRepository produtoRepository)
            : base(produtoRepository)
        {
            _produtoRepository = produtoRepository;
        }

        public List<Produto> ObterPorNome(string nome)
        {
            return _produtoRepository.GetByNome(nome);
        }
    }
}
