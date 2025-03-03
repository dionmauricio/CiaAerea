using CiaAerea.Entities.Aircraft;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaAerea.EntityConfigurations.Aircraft;

public class AeronaveConfiguration : IEntityTypeConfiguration<Aeronave>
{
    public void Configure(EntityTypeBuilder<Aeronave> builder)
    {
        builder.ToTable("aeronaves");

        builder.HasKey(aeronave => aeronave.Id);

        builder.Property(aeronave => aeronave.Fabricante)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(aeronave => aeronave.Modelo)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(50);

        builder.Property(aeronave => aeronave.Modelo)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(10);

        builder.HasMany(aeronave => aeronave.Manutencoes)
            .WithOne(manutencao => manutencao.Aeronave)
            .HasForeignKey(manutencao => manutencao.AeronaveId);
    }
}
