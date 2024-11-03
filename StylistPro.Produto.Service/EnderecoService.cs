using RestSharp;
using StylistPro.Produto.Domain.Entities;
using StylistPro.Produto.Domain.Interfaces;

namespace StylistPro.Produto.Service
{
    public class EnderecoService : IEnderecoService
    {
        private readonly RestClient _restClient;

        public EnderecoService()
        {
            _restClient = new RestClient("https://viacep.com.br/ws/");
        }

        public async Task<Endereco?> ObterEnderecoPorCepAsync(string cep)
        {
            var request = new RestRequest($"{cep}/json/", Method.Get);
            var response = await _restClient.ExecuteAsync<Endereco>(request);

            if (!response.IsSuccessful || response.Data == null)
                return null;

            return response.Data;
        }
    }
}
