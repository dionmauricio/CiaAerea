using CiaAerea.Entities.Cancellations;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CiaAerea.EntityConfigurations.Cancellations;

public class CancelamentoConfiguration : IEntityTypeConfiguration<Cancelamento>
{
    public void Configure(EntityTypeBuilder<Cancelamento> builder)
    {
        builder.ToTable("cancelamentos");

        builder.HasKey(cancelamento => cancelamento.Id);

        builder.Property(cancelamento => cancelamento.Motivo)
            .HasColumnType("text")
            .IsRequired()
            .HasMaxLength(100);

        builder.Property(cancelamento => cancelamento.DataHoraNotificacao)
            .IsRequired();
    }
}
