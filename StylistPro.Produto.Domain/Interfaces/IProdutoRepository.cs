using StylistPro.Produto.Domain.Entities;

namespace StylistPro.Produto.Domain.Interfaces
{
    public interface IProdutoRepository
    {
        ProdutoEntity? ObterPorId(int id);
        IEnumerable<ProdutoEntity>? ObterTodos();
        ProdutoEntity? SalvarDados(ProdutoEntity produto);
        ProdutoEntity? EditarDados(ProdutoEntity produto);
        ProdutoEntity? DeletarDados(int id);
    }
}