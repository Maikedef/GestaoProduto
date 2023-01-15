using GestaoProduto.Application.Dtos.Produtos;
using GestaoProduto.Application.Interfaces.Produtos;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using System.Threading.Tasks;

namespace GestaoProduto.API.Controllers
{
    [ApiController]
    [Route("v1/produtos")]
    public class ProdutoController : ControllerBase
    {
        private readonly IApplicationUseCaseProduto _serviceProduto;

        public ProdutoController(IApplicationUseCaseProduto serviceProduto)
        {
            _serviceProduto = serviceProduto;
        }
        [HttpGet("{id}")]
        [ProducesResponseType(typeof(RetornarProdutoDto),(int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetByIdAsync([FromRoute] int id)
        {
            var produtoDto = await _serviceProduto.GetByIDAsync(id);
            return Ok(produtoDto);
        }

        [HttpGet]
        [ProducesResponseType(typeof(RetornarProdutoDto), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> GetAllAsync
            (
                [FromQuery] int pagina, 
                [FromQuery] int limite, 
                [FromQuery] string descricaoProduto = ""
            )
        {
            var produtosDto = await _serviceProduto.GetAllAsync(pagina, limite, descricaoProduto);
            return Ok(produtosDto);
        }

        [HttpPost]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.Created)]
        public async Task<IActionResult> InsertAsync([FromBody] InserirProdutoDto produto)
        {
            string result = await _serviceProduto.InsertAsync(produto);
            return Ok(result);
        }

        [HttpPut]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> UpdateAsync([FromBody] AtualizarProdutoDto produto)
        {
            string result = await _serviceProduto.UpdateAsync(produto);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [ProducesResponseType(typeof(string), (int)HttpStatusCode.OK)]
        public async Task<IActionResult> DeleteAsync([FromRoute] int id)
        {
            string result = await _serviceProduto.DeleteAsync(id);
            return Ok(result);
        }
    }
}
