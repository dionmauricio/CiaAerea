using CiaAerea.Entities.Flights;
using CiaAerea.Entities.Maintenance;

namespace CiaAerea.Entities.Aircraft;

public class Aeronave
{
    public int Id { get; set; }
    public string Fabricante { get; set; }
    public string Modelo { get; set; }
    public string Codigo { get; set; }
    public ICollection<Manutencao> Manutencoes { get; set; } = null!;
    public ICollection<Voo> Voos { get; set; } = null!;

    public Aeronave(
        string fabricante,
        string modelo,
        string codigo)
    {
        Fabricante = fabricante;
        Modelo = modelo;
        Codigo = codigo;
    }
}
