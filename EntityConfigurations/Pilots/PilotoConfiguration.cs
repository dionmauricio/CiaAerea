using CiaAerea.Entities.Pilots;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaAerea.EntityConfigurations.Pilots;

public class PilotoConfiguration : IEntityTypeConfiguration<Piloto>
{
    public void Configure(EntityTypeBuilder<Piloto> builder)
    {
        builder.ToTable("pilotos");

        builder.HasKey(piloto => piloto.Id);

        builder.Property(piloto => piloto.NomeCompleto)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(piloto => piloto.Matricula)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(10);

        builder.HasIndex(piloto => piloto.Matricula)
            .IsUnique();
    }
}
