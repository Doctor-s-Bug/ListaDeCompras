using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm.Config;

public class CategoriaConfiguration : IEntityTypeConfiguration<Categoria>
{
    public void Configure(EntityTypeBuilder<Categoria> builder)
    {
        //Cria a tabela TB_Categorias
        builder.ToTable("TB_Categorias");

        //Define a chave primaria
        builder.HasKey(c => c.Id)
            .HasName("PK_TBCategoria"); //Nomeia a Chave Primaria

        //Pro entity nunca gerar um valor automatico pro ID
        builder.Property(c => c.Id)
            .ValueGeneratedNever();

        //Propriedades da tabela seguindo o objeto

        builder.Property(c => c.Nome)
            .IsRequired()
            .HasMaxLength(50);


        builder.Property(c => c.Cor)
            .IsRequired();
    }
}
