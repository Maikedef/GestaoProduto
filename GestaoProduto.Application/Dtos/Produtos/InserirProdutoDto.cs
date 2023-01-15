using System;

namespace GestaoProduto.Application.Dtos.Produtos
{
    public class InserirProdutoDto
    {
        public string DescricaoProduto { get; set; }
        public DateTime DataFabricacao { get; set; }
        public DateTime DataValidade { get; set; }
        public int IdFornecedor { get; set; }
        public string DescricaoFornecedor { get; set; }
        public string CnpjFornecedor { get; set; }
    }
}
