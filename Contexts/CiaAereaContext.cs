using CiaAerea.Entities.Aircraft;
using CiaAerea.Entities.Cancellations;
using CiaAerea.Entities.Flights;
using CiaAerea.Entities.Maintenance;
using CiaAerea.Entities.Pilots;
using Microsoft.EntityFrameworkCore;

namespace CiaAerea.Contexts;

public class CiaAereaContext : DbContext
{
    public DbSet<Aeronave> Aeronaves => Set<Aeronave>();
    public DbSet<Piloto> Pilotos => Set<Piloto>();
    public DbSet<Voo> Voos => Set<Voo>();
    public DbSet<Cancelamento> cancelamentos => Set<Cancelamento>();
    public DbSet<Manutencao> Manutencoes => Set<Manutencao>();
}
