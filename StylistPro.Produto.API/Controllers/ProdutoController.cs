using StylistPro.Produto.Application.Dtos;
using StylistPro.Produto.Domain.Entities;
using StylistPro.Produto.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;
using System.Net;

namespace StylistPro.Produto.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProdutoController : ControllerBase
    {
        private readonly IProdutoApplicationService _produtoApplicationService;

        public ProdutoController(IProdutoApplicationService produtoApplicationService)
        {
            _produtoApplicationService = produtoApplicationService;
        }

        /// <summary>
        /// Metodo para obter todos os dados de produtos
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        [Produces<IEnumerable<ProdutoEntity>>]
        public IActionResult Get()
        {
            var produtos = _produtoApplicationService.ObterTodosProdutos();

            if (produtos is not null)
                return Ok(produtos);

            return BadRequest("Não foi possível obter os dados");
        }

        /// <summary>
        /// Método para obter um produto
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <returns></returns>
        [HttpGet("{id}")]
        [Produces<ProdutoEntity>]

        public IActionResult GetPorId(int id)
        {
            var produtos = _produtoApplicationService.ObterProdutoPorId(id);

            if (produtos is not null)
                return Ok(produtos);

            return BadRequest("Não foi possível obter os dados");
        }


        /// <summary>
        /// Método para salvar o produto
        /// </summary>
        /// <param name="entity">Modelo de dados do Produto</param>
        /// <returns></returns>
        [HttpPost]
        [Produces<ProdutoEntity>]
        public IActionResult Post(ProdutoDto entity)
        {
            try
            {
                var produtos = _produtoApplicationService.SalvarDadosProduto(entity);

                if (produtos is not null)
                    return Ok(produtos);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }

        /// <summary>
        /// Método para editar o produto
        /// </summary>
        /// <param name="id"> Identificador do Produto</param>
        /// <param name="entity">Modelo de dados do Produto</param>
        /// <returns></returns>
        [HttpPut("{id}")]
        [Produces<ProdutoEntity>]
        public IActionResult Put(int id, [FromBody] ProdutoDto entity)
        {
            try
            {
                var produtos = _produtoApplicationService.EditarDadosProduto(id, entity);

                if (produtos is not null)
                    return Ok(produtos);

                return BadRequest("Não foi possivel salvar os dados");
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    Error = ex.Message,
                    status = HttpStatusCode.BadRequest,
                });
            }
        }


        /// <summary>
        /// Método para deletar um produto
        /// </summary>
        /// <param name="id">Identificador do produto</param>
        /// <returns></returns>
        [HttpDelete("{id}")]
        [Produces<ProdutoEntity>]

        public IActionResult Delete(int id)
        {
            var produtos = _produtoApplicationService.DeletarDadosProduto(id);

            if (produtos is not null)
                return Ok(produtos);

            return BadRequest("Não foi possível deletar os dados");
        }

        [HttpGet("busca/endereco/{cep}")]
        [Produces<Endereco>]
        public async Task<IActionResult> GetDataService(string cep) 
        {
            var endereco = await _produtoApplicationService.ObterEnderecoPorCepAsync(cep);

            if (endereco is not null)
                return Ok(endereco);

            return BadRequest("Não foi possível obter os dados do endereço");
        }
    }
}
