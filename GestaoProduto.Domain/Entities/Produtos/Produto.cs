using GestaoProduto.Domain.Enuns.Produtos;
using System;

namespace GestaoProduto.Domain.Entities.Produtos
{
    public class Produto
    {
        public int Id { get; private set; }
        public string DescricaoProduto { get; private set; }
        public SituacaoProduto SituacaoProduto { get; private set; }
        public DateTime DataFabricacao { get; private set; }
        public DateTime DataValidade { get; private set; }
        public int IdFornecedor { get; private set; }
        public string DescricaoFornecedor { get; private set; }
        public string CnpjFornecedor { get; private set; }
        
        public Produto()
        {
            SituacaoProduto = SituacaoProduto.Ativo;
        }

        public void Update(Produto produto)
        {
            DescricaoProduto = produto.DescricaoProduto; ;
            DataFabricacao = produto.DataFabricacao;
            DataValidade = produto.DataValidade;
            IdFornecedor = produto.IdFornecedor;
            DescricaoFornecedor = produto.DescricaoFornecedor;
            CnpjFornecedor = produto.CnpjFornecedor;
        }

        public void Delete()
        {
            SituacaoProduto = SituacaoProduto.Inativo;
        }
    }
}
