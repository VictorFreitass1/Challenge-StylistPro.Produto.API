using StylistPro.Produto.Data.AppData;
using StylistPro.Produto.Data.Repositories;
using StylistPro.Produto.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace StylistPro.Produto.Tests
{
    public class ProdutoRepositoryTests
    {
        private readonly DbContextOptions<ApplicationContext> _options;
        private readonly ApplicationContext _context;
        private readonly ProdutoRepository _produtoRepository;

        public ProdutoRepositoryTests()
        {
            _options = new DbContextOptionsBuilder<ApplicationContext>()
                .UseInMemoryDatabase(databaseName: "TestDatabase")
                .Options;

            _context = new ApplicationContext(_options);
            _produtoRepository = new ProdutoRepository(_context);
        }

        [Fact]
        public void SalvarDados_DeveAdicionarProdutoERetornarProdutoEntity()
        {
            // Arrange
            var produto = new ProdutoEntity { Nome = "Victor", Descricao = "Roupa"};

            // Act
            var resultado = _produtoRepository.SalvarDados(produto);

            // Assert
            var produtoeNoDb = _context.Produto.FirstOrDefault(c => c.Id == resultado.Id);
            Assert.NotNull(produtoeNoDb);
            Assert.Equal(produto.Nome, produtoeNoDb.Nome);
            Assert.Equal(produto.Descricao, produtoeNoDb.Descricao);
        }

        [Fact]
        public void EditarDados_DeveAtualizarProdutoERetornarProdutoEntity_QuandoProdutoExiste()
        {
            // Arrange
            var produto = new ProdutoEntity {Nome = "Humberto", Descricao = "Calçado"};
            _context.Produto.Add(produto);
            _context.SaveChanges();

            produto.Nome = "Humberto Atualizado";
            produto.Descricao = "Calçado Atualizado";

            // Act
            var resultado = _produtoRepository.EditarDados(produto);

            // Assert
            var produtoNoDb = _context.Produto.FirstOrDefault(c => c.Id == produto.Id);
            Assert.NotNull(produtoNoDb);
            Assert.Equal("Humberto Atualizado", produtoNoDb.Nome);
            Assert.Equal("Calçado Atualizado", produtoNoDb.Descricao);
        }

        [Fact]
        public void ObterPorId_DeveRetornarProdutoEntity_QuandoProdutoExiste()
        {
            // Arrange
            var produto = new ProdutoEntity { Nome = "Matheus", Descricao = "Acessório"};
            _context.Produto.Add(produto);
            _context.SaveChanges();

            // Act
            var resultado = _produtoRepository.ObterPorId(produto.Id);

            // Assert
            Assert.NotNull(resultado);
            Assert.Equal(produto.Id, resultado.Id);
            Assert.Equal(produto.Nome, resultado.Nome);
            Assert.Equal(produto.Descricao, resultado.Descricao);
        }

        [Fact]
        public void ObterTodos_DeveRetornarListaDeProdutos_QuandoExistiremProdutos()
        {
            // Arrange
            _context.Produto.RemoveRange(_context.Produto);
            _context.SaveChanges();

            var produtos = new List<ProdutoEntity>
            {
                new ProdutoEntity { Nome = "Mariana", Descricao = "Roupa"},
                new ProdutoEntity { Nome = "Jaqueline", Descricao = "Calçado"}
            };
            _context.Produto.AddRange(produtos);
            _context.SaveChanges();

            // Act
            var resultado = _produtoRepository.ObterTodos();

            // Assert
            Assert.Equal(produtos.Count, resultado.Count());
            Assert.Contains(resultado, p => p.Nome == "Mariana");
            Assert.Contains(resultado, p => p.Nome == "Jaqueline");
        }

        [Fact]
        public void DeletarDados_DeveRemoverProdutoRetornarProdutoEntity_QuandoProdutoExiste()
        {
            // Arrange
            var produto = new ProdutoEntity { Nome = "Breno", Descricao = "Acessório"};
            _context.Produto.Add(produto);
            _context.SaveChanges();

            // Act
            var resultado = _produtoRepository.DeletarDados (produto.Id);

            // Assert
            var produtoNoDb = _context.Produto.FirstOrDefault(c => c.Id == produto.Id);

            Assert.Null(produtoNoDb);
            Assert.Equal(produto, resultado);
        }

    }
}
