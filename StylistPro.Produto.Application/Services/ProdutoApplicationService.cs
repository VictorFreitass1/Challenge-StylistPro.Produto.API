using StylistPro.Produto.Domain.Entities;
using StylistPro.Produto.Domain.Interfaces;
using StylistPro.Produto.Domain.Interfaces.Dtos;

namespace StylistPro.Produto.Application.Services
{
    public class ProdutoApplicationService : IProdutoApplicationService
    {
        private readonly IProdutoRepository _produtoRepository;
        private readonly IEnderecoService _enderecoService;

        public ProdutoApplicationService(IProdutoRepository produtoRepository, IEnderecoService enderecoService)
        {
            _produtoRepository = produtoRepository;
            _enderecoService = enderecoService;
        }

        public ProdutoEntity? DeletarDadosProduto(int id)
        {
            return _produtoRepository.DeletarDados(id);
        }

        public ProdutoEntity? EditarDadosProduto(int id, IProdutoDto entity)
        {
            entity.Validate();

            return _produtoRepository.EditarDados(new ProdutoEntity
            {
                Id = id,
                Nome = entity.Nome,
                Descricao = entity.Descricao,
            });
        }

        public ProdutoEntity? ObterProdutoPorId(int id)
        {
            return _produtoRepository.ObterPorId(id);
        }

        public IEnumerable<ProdutoEntity> ObterTodosProdutos()
        {
            return _produtoRepository.ObterTodos();
        }

        public ProdutoEntity? SalvarDadosProduto(IProdutoDto entity)
        {
            entity.Validate();

            return _produtoRepository.SalvarDados(new ProdutoEntity
            {
                Nome = entity.Nome,
                Descricao = entity.Descricao,
            });
        }
        public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            var endereco = await _enderecoService.ObterEnderecoPorCepAsync(cep);

            if (endereco is not null)
                return endereco;

            return null;

        }
    }
}
