using ApiProdutos.Application.Requests;
using ApiProdutos.Application.Responses;
using ApiProdutos.Domain.Contracts.Services;
using ApiProdutos.Domain.Entities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiProdutos.Application.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutosController : ControllerBase
    {
        private readonly IProdutoDomainService _produtoDomainService;

        public ProdutosController(IProdutoDomainService produtoDomainService)
        {
            _produtoDomainService = produtoDomainService;
        }

        [HttpPost]
        public IActionResult Post(ProdutosPostRequest request)
        {
            try
            {
                var produto = new Produto
                {
                    Id = Guid.NewGuid(),
                    Nome = request.Nome,
                    Preco = request.Preco.Value,
                    Quantidade = request.Quantidade.Value,
                    Descricao = request.Descricao,
                    DataCadastro = DateTime.Now,
                    Categoria = (Categoria)request.Categoria
                };

                _produtoDomainService.Cadastrar(produto);

                return StatusCode(201, new { mensagem = "Produto cadastrado com sucesso.", produto = Parse(produto) });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpPut]
        public IActionResult Put(ProdutosPutRequest request)
        {
            try
            {
                if (_produtoDomainService.ObterPorId(request.IdProduto.Value) == null)
                    return StatusCode(400, new { mensagem = "Produto não encontrado, verifique o ID informado." });

                var produto = new Produto
                {
                    Id = request.IdProduto.Value,
                    Nome = request.Nome,
                    Preco = request.Preco.Value,
                    Quantidade = request.Quantidade.Value,
                    Descricao = request.Descricao,
                    DataCadastro = DateTime.Now,
                    Categoria = (Categoria)request.Categoria
                };

                _produtoDomainService.Atualizar(produto);

                return StatusCode(200, new { mensagem = "Produto atualizado com sucesso.", produto = Parse(produto) });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpDelete("{id}")]
        public IActionResult Delete(Guid id)
        {
            try
            {
                var produto = _produtoDomainService.ObterPorId(id);

                if (produto == null)
                    return StatusCode(400, new { mensagem = "Produto não encontrado, verifique o ID informado." });

                _produtoDomainService.Excluir(produto);

                return StatusCode(200, new { mensagem = "Produto excluído com sucesso.", produto = Parse(produto) });
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            try
            {
                var lista = new List<ProdutoResponse>();

                foreach (var item in _produtoDomainService.ObterTodos())
                {
                    lista.Add(Parse(item));
                }

                return StatusCode(200, lista);
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(Guid id)
        {
            try
            {
                var produto = _produtoDomainService.ObterPorId(id);

                if (produto != null)
                    return StatusCode(200, new { produto = Parse(produto) });
                else
                    return StatusCode(204); //NO CONTENT
            }
            catch (Exception e)
            {
                return StatusCode(500, new { mensagem = e.Message });
            }
        }

        private ProdutoResponse Parse(Produto produto)
        {
            return new ProdutoResponse
            {
                Id = produto.Id,
                Nome = produto.Nome,
                Descricao = produto.Descricao,
                Preco = produto.Preco,
                Quantidade = produto.Quantidade,
                Total = produto.Preco * produto.Quantidade,
                DataCadastro = produto.DataCadastro,
                Categoria = new CategoriaResponse
                {
                    Id = (int)produto.Categoria,
                    Nome = produto.Categoria.ToString()
                }
            };
        }
    }
}



