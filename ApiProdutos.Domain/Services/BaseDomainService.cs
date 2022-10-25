using ApiProdutos.Domain.Contracts.Repositories;
using ApiProdutos.Domain.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ApiProdutos.Domain.Services
{
    public abstract class BaseDomainService<TEntity> : IBaseDomainService<TEntity>
        where TEntity : class
    {
        private readonly IBaseRepository<TEntity> _baseRepository;

        protected BaseDomainService(IBaseRepository<TEntity> baseRepository)
        {
            _baseRepository = baseRepository;
        }

        public virtual void Cadastrar(TEntity entity)
        {
            _baseRepository.Create(entity);
        }

        public virtual void Atualizar(TEntity entity)
        {
            _baseRepository.Update(entity);
        }

        public virtual void Excluir(TEntity entity)
        {
            _baseRepository.Delete(entity);
        }

        public virtual List<TEntity> ObterTodos()
        {
            return _baseRepository.GetAll();
        }

        public virtual TEntity ObterPorId(Guid id)
        {
            return _baseRepository.Get(id);
        }
    }
}
