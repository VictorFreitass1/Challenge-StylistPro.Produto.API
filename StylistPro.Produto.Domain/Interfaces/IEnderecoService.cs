using StylistPro.Produto.Domain.Entities;

namespace StylistPro.Produto.Domain.Interfaces
{
    public interface IEnderecoService
    {
        Task<Endereco?> ObterEnderecoPorCepAsync(string cep);
    }
}
