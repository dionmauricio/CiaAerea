using CiaAerea.Entities.Cancellations;
using CiaAerea.Entities.Flights;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaAerea.EntityConfigurations.Flights;

public class VooConfiguration : IEntityTypeConfiguration<Voo>
{
    public void Configure(EntityTypeBuilder<Voo> builder)
    {
        builder.ToTable("voos");

        builder.HasKey(voo => voo.Id);

        builder.Property(voo => voo.Origem)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(voo => voo.Destino)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(3);

        builder.Property(voo => voo.DataHoraPartida)
            .IsRequired();

        builder.Property(voo => voo.DataHoraChegada)
            .IsRequired();

        builder.HasOne(voo => voo.Piloto)
            .WithMany(piloto => piloto.Voos)
            .HasForeignKey(voo => voo.PilotoId);

        builder.HasOne(voo => voo.Aeronave)
            .WithMany(aeronave => aeronave.Voos)
            .HasForeignKey(voo => voo.AeronaveId);

        builder.HasOne(voo => voo.Cancelamento)
            .WithOne(cancelamento => cancelamento.Voo)
            .HasForeignKey<Cancelamento>(cancelamento => cancelamento.VooId);
    }
}
