using CiaAerea.Entities.Aircraft;
using CiaAerea.Entities.Cancellations;
using CiaAerea.Entities.Flights;
using CiaAerea.Entities.Maintenance;
using CiaAerea.Entities.Pilots;
using CiaAerea.EntityConfigurations.Aircraft;
using CiaAerea.EntityConfigurations.Cancellations;
using CiaAerea.EntityConfigurations.Flights;
using CiaAerea.EntityConfigurations.Maintenance;
using CiaAerea.EntityConfigurations.Pilots;
using Microsoft.EntityFrameworkCore;

namespace CiaAerea.Contexts;

public class CiaAereaContext : DbContext
{
    private readonly IConfiguration _configuration;

    public CiaAereaContext(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Piloto> Pilotos => Set<Piloto>();
    public DbSet<Voo> Voos => Set<Voo>();
    public DbSet<Cancelamento> cancelamentos => Set<Cancelamento>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();

    protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
    {
        optionsBuilder.UseNpgsql(_configuration.GetConnectionString("CiaAerea"));

        base.OnConfiguring(optionsBuilder);
    }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.ApplyConfiguration(new AeronaveConfiguration());
        modelBuilder.ApplyConfiguration(new PilotoConfiguration());
        modelBuilder.ApplyConfiguration(new VooConfiguration());
        modelBuilder.ApplyConfiguration(new CancelamentoConfiguration());
        modelBuilder.ApplyConfiguration(new ManutencaoConfiguration());

        base.OnModelCreating(modelBuilder);
    }
}
