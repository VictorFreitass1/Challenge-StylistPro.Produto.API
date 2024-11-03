using Moq;
using StylistPro.Produto.Application.Services;
using StylistPro.Produto.Domain.Entities;
using StylistPro.Produto.Domain.Interfaces;
using StylistPro.Produto.Domain.Interfaces.Dtos;

namespace StylistPro.Produto.Tests
{
    public class ProdutoApplicationServiceTests
    {
        private readonly Mock<IEnderecoService> _enderecoServiceMock;
        private readonly Mock<IProdutoRepository> _repositoryMock;

        private readonly ProdutoApplicationService _produtoService;

    
        public ProdutoApplicationServiceTests()
        {
            _repositoryMock = new Mock<IProdutoRepository>();
            _enderecoServiceMock = new Mock<IEnderecoService>();

            _produtoService = new ProdutoApplicationService(_repositoryMock.Object, _enderecoServiceMock.Object);
        }

        [Fact]
        public void SalvarDadosProduto_DeveRetornarProdutoEntity_QuandoAdicionarComSucesso()
        {
            // Arrange
            var produtoDtoMock = new Mock<IProdutoDto>();
            produtoDtoMock.Setup(c => c.Nome).Returns("Victor");
            produtoDtoMock.Setup(c => c.Descricao).Returns("Roupa");

            var produtoEsperado = new ProdutoEntity { Nome = "Victor", Descricao = "Roupa" };

            _repositoryMock.Setup(r => r.SalvarDados(It.IsAny<ProdutoEntity>())).Returns(produtoEsperado);

            // Act
            var resultado = _produtoService.SalvarDadosProduto (produtoDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(produtoEsperado.Nome, resultado.Nome);
            Assert.Equal(produtoEsperado.Descricao, resultado.Descricao);
        }

        [Fact]
        public void EditarDadosProduto_DeveRetornarProdutoEntity_QuandoEditarComSucesso()
        {
            // Arrange
            var produtoDtoMock = new Mock<IProdutoDto>();
            produtoDtoMock.Setup(c => c.Nome).Returns("Humberto");
            produtoDtoMock.Setup(c => c.Descricao).Returns("Calçado");

            var produtoEsperado = new ProdutoEntity { Id = 1, Nome = "Humberto", Descricao = "Calçado" };
            _repositoryMock.Setup(r => r.EditarDados(It.IsAny<ProdutoEntity>())).Returns(produtoEsperado);

            // Act
            var resultado = _produtoService.EditarDadosProduto(1, produtoDtoMock.Object);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(produtoEsperado.Id, resultado.Id);
            Assert.Equal(produtoEsperado.Nome, resultado.Nome);
            Assert.Equal(produtoEsperado.Descricao, resultado.Descricao);
        }

        [Fact]
        public void ObterProdutoPorId_DeveRetornarProdutoEntity_QuandoProdutoExiste()
        {
            // Arrange
            var produtoEsperado = new ProdutoEntity { Id = 1, Nome = "Matheus", Descricao = "Acessório"};
            _repositoryMock.Setup(r => r.ObterPorId(1)).Returns(produtoEsperado);

            // Act
            var resultado = _produtoService.ObterProdutoPorId(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(produtoEsperado.Id, resultado.Id);
            Assert.Equal(produtoEsperado.Nome, resultado.Nome);
            Assert.Equal(produtoEsperado.Descricao, resultado.Descricao);
        }

        [Fact]
        public void ObterTodosProdutos_DeveRetornarListaDeProdutos_QuandoExistiremProdutos()
        {
            // Arrange
            var produtosEsperados = new List<ProdutoEntity>
            {
                new ProdutoEntity { Id = 1, Nome = "Mariana", Descricao = "Roupa"},
                new ProdutoEntity { Id = 2, Nome = "Jaqueline", Descricao = "Calçado"}
            };
            _repositoryMock.Setup(r => r.ObterTodos()).Returns(produtosEsperados);

            // Act
            var resultado = _produtoService.ObterTodosProdutos();

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(2, resultado.Count());
            Assert.Equal(produtosEsperados.First().Nome, resultado.First().Nome);
        }
      

        [Fact]
        public void RemoverProduto_DeveRetornarProdutoEntity_QuandoRemoverComSucesso()
        {
            // Arrange
            var produtoEsperado = new ProdutoEntity { Id = 1, Nome = "Breno", Descricao = "Acessório"};
            _repositoryMock.Setup(r => r.DeletarDados(1)).Returns(produtoEsperado);

            // Act
            var resultado = _produtoService.DeletarDadosProduto(1);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(produtoEsperado.Id, resultado.Id);
            Assert.Equal(produtoEsperado.Nome, resultado.Nome);
            Assert.Equal(produtoEsperado.Descricao, resultado.Descricao);
        }

    }
}
