using CiaAerea.Entities.Maintenance;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaAerea.EntityConfigurations.Maintenance;

public class ManutencaoConfiguration : IEntityTypeConfiguration<Manutencao>
{
    public void Configure(EntityTypeBuilder<Manutencao> builder)
    {
        builder.ToTable("manutencoes");

        builder.HasKey(manutencao => manutencao.Id);

        builder.Property(manutencao => manutencao.DataHora)
            .IsRequired();

        builder.Property(manutencao => manutencao.Tipo)
            .IsRequired();

        builder.Property(manutencao => manutencao.Observacao)
            .HasColumnType("text")
            .IsRequired(false)
            .HasMaxLength(100);
    }
}
