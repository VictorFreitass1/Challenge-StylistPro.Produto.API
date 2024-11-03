using StylistPro.Produto.Domain.Entities;
using StylistPro.Produto.Domain.Interfaces.Dtos;

namespace StylistPro.Produto.Domain.Interfaces
{
    public interface IProdutoApplicationService
    {
        IEnumerable<ProdutoEntity> ObterTodosProdutos();
        ProdutoEntity? ObterProdutoPorId(int id);
        ProdutoEntity? SalvarDadosProduto(IProdutoDto entity);
        ProdutoEntity? EditarDadosProduto(int id, IProdutoDto entity);
        ProdutoEntity? DeletarDadosProduto(int id);
        Task<Endereco?> ObterEnderecoPorCepAsync(string cep);
    }
}