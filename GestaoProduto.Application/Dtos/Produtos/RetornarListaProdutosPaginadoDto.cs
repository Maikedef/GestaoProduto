using System.Collections.Generic;

namespace GestaoProduto.Application.Dtos.Produtos
{
    public class RetornarListaProdutosPaginadoDto
    {
        public int TotalRegistros { get; set; }
        public List<RetornarProdutoDto> Produtos {get;set;}
    }
}
