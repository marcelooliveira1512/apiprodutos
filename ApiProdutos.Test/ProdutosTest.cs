using ApiProdutos.Application.Requests;
using ApiProdutos.Application.Responses;
using Bogus;
using FluentAssertions;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Xunit;

namespace ApiProdutos.Test
{
    public class ProdutosTest
    {
        private readonly HttpClient _httpClient;

        public ProdutosTest()
        {
            var application = new WebApplicationFactory<Program>();
            _httpClient = application.CreateClient();
        }

        [Fact]
        public async Task<ProdutoResponse> Test_Post_Produtos_Returns_Ok()
        {
            #region Dados do teste

            var faker = new Faker("pt_BR");

            var request = new ProdutosPostRequest
            {
                Nome = faker.Commerce.ProductName(),
                Preco = decimal.Parse(faker.Commerce.Price(1, 1000, 2, null)),
                Quantidade = new Random().Next(100),
                Descricao = faker.Commerce.ProductDescription(),
                Categoria = new Random().Next(1, 4)
            };

            var content = new StringContent
                (JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            #endregion

            #region Requisição para cadastro do produto

            var result = await _httpClient.PostAsync("/api/produtos", content);

            #endregion

            #region Validação do resultado

            result.StatusCode
                .Should().Be(HttpStatusCode.Created);

            return JsonConvert.DeserializeObject<ProdutoTestResponse>
              (result.Content.ReadAsStringAsync().Result).Produto;

            #endregion
        }

        [Fact]
        public async Task Test_Put_Produtos_Returns_Ok()
        {
            #region Dados do teste

            var produto = await Test_Post_Produtos_Returns_Ok();

            var faker = new Faker("pt_BR");

            var request = new ProdutosPutRequest
            {
                IdProduto = produto.Id,
                Nome = faker.Commerce.ProductName(),
                Preco = decimal.Parse(faker.Commerce.Price(1, 1000, 2, null)),
                Quantidade = new Random().Next(100),
                Descricao = faker.Commerce.ProductDescription(),
                Categoria = new Random().Next(1, 4)
            };

            var content = new StringContent
                (JsonConvert.SerializeObject(request), Encoding.UTF8, "application/json");

            #endregion

            #region Requisição para atualização do produto

            var result = await _httpClient.PutAsync("/api/produtos", content);

            #endregion

            #region Validação do resultado

            result.StatusCode
                .Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Test_Delete_Produtos_Returns_Ok()
        {
            #region Dados do teste

            var produto = await Test_Post_Produtos_Returns_Ok();

            #endregion

            #region Requisição para exclusão do produto

            var result = await _httpClient.DeleteAsync("/api/produtos/" + produto.Id);

            #endregion

            #region Validação do resultado

            result.StatusCode
                .Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Test_GetAll_Produtos_Returns_Ok()
        {
            #region Dados do teste

            await Test_Post_Produtos_Returns_Ok();

            #endregion

            #region Requisição para exclusão do produto

            var result = await _httpClient.GetAsync("/api/produtos");

            #endregion

            #region Validação do resultado

            result.StatusCode
                .Should().Be(HttpStatusCode.OK);

            #endregion
        }

        [Fact]
        public async Task Test_GetById_Produtos_Returns_Ok()
        {
            #region Dados do teste

            var produto = await Test_Post_Produtos_Returns_Ok();

            #endregion

            #region Requisição para exclusão do produto

            var result = await _httpClient.GetAsync("/api/produtos/" + produto.Id);

            #endregion

            #region Validação do resultado

            result.StatusCode
                .Should().Be(HttpStatusCode.OK);

            #endregion
        }
    }

    /// <summary>
    /// Modelo de dados para obter o retorno de um produto cadastrado
    /// </summary>
    public class ProdutoTestResponse
    {
        public string? Mensagem { get; set; }
        public ProdutoResponse? Produto { get; set; }
    }
}


