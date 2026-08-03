using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm.Config;

public class ProdutoConfigurations : IEntityTypeConfiguration<Produto>
{
    public void Configure(EntityTypeBuilder<Produto> builder)
    {
        builder.ToTable("TB_Produto");

        builder.HasKey(p => p.Id)
        .HasName("PK_TBProduto");

        builder.Property(p => p.Id)
        .ValueGeneratedNever();

        builder.Property(p => p.Nome)
        .IsRequired()
        .HasMaxLength(100);

        builder.Property(p => p.PrecoAproximado)
        .IsRequired();

        builder.Property(p => p.UnidadeMedida)
        .IsRequired();

        builder.HasOne(p => p.Categoria)
        .WithMany(c => c.Produtos)
        .HasForeignKey("CategoriaId")
        .HasConstraintName("FK_TBProduto_TBCategoria")
        .OnDelete(DeleteBehavior.Restrict);
    }
}
