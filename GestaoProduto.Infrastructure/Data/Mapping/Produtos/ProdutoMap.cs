using GestaoProduto.Domain.Entities.Produtos;
using GestaoProduto.Domain.Enuns.Produtos;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace GestaoProduto.Infrastructure.Data.Mapping.Produtos
{
    public class ProdutoMap : IEntityTypeConfiguration<Produto>
    {
        public void Configure(EntityTypeBuilder<Produto> builder)
        {
            builder.ToTable("produto");

            builder.HasKey(prop => prop.Id);

            builder.Property(prop => prop.DescricaoProduto)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .IsRequired()
                .HasColumnName("descricao_produto")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.SituacaoProduto)
               .HasColumnName("situacao_produto")
               .HasColumnType("enum('Ativo', 'Inativo')")
               .HasDefaultValue(SituacaoProduto.Ativo);

            builder.Property(prop => prop.DataFabricacao)
                .HasColumnName("data_fabricacao")
                .HasColumnType("date");

            builder.Property(prop => prop.DataValidade)
                .HasColumnName("data_validade")
                .HasColumnType("date");

            builder.Property(prop => prop.IdFornecedor)
                .HasColumnName("id_fornecedor")
                .HasColumnType("int");

            builder.Property(prop => prop.DescricaoFornecedor)
                .HasConversion(prop => prop.ToString(), prop => prop)
                .HasColumnName("descricao_fornecedor")
                .HasColumnType("varchar(100)");

            builder.Property(prop => prop.CnpjFornecedor)
                .HasColumnName("cnpj_fornecedor")
                .HasColumnType("varchar(20)");

        }
    }
}
