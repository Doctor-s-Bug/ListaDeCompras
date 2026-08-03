using ClubeDaLeituraWeb.WebApp.ModuloListaDeCompra.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm.Config;

public class ListaDeComprasConfigurations : IEntityTypeConfiguration<ListaDeCompra>
{
    public void Configure(EntityTypeBuilder<ListaDeCompra> builder)
    {
        builder.ToTable("TB_ListaDeCompras");

        builder.HasKey(l => l.Id)
        .HasName("PK_ListaDeCompras");

        builder.Property(l => l.Nome)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(l => l.DataCriacao)
        .IsRequired();

        builder.Property(l => l.StatusLista)
        .IsRequired();

        builder.Property(l => l.ValorTotal)
        .IsRequired()
        .HasPrecision(18,  2);

        builder.HasMany(l => l.Produtos)
        .WithOne(p => p.ListaDeCompra)
        .HasForeignKey("ItensProdutoId")
        .HasConstraintName("FK_TBListaDeCompras_TBItensProduto");
    }
}
