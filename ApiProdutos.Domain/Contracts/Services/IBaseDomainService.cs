using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Domain.Contracts.Services
{
    public interface IBaseDomainService<TEntity>
        where TEntity : class
    {
        void Cadastrar(TEntity entity);
        void Atualizar(TEntity entity);
        void Excluir(TEntity entity);
        List<TEntity> ObterTodos();
        TEntity ObterPorId(Guid id);
    }
}
