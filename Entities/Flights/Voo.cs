using CiaAerea.Entities.Aircraft;
using CiaAerea.Entities.Cancellations;
using CiaAerea.Entities.Pilots;

namespace CiaAerea.Entities.Flights;

public class Voo
{
    public int Id { get; set; }
    public string Origem { get; set; }
    public string Destino { get; set; }
    public DateTime DataHoraPartida { get; set; }
    public DateTime DataHoraChegada { get; set; }
    public int AeronaveId { get; set; }
    public int PilotoId { get; set; }
    public Aeronave Aeronave { get; set; } = null!;
    public Piloto Piloto { get; set; } = null!;
    public Cancelamento? Cancelamento { get; set; }

    public Voo(
        string origem,
        string destino,
        DateTime dataHoraPartida,
        DateTime dataHoraChegada,
        int aeronaveId,
        int pilotoId)
    {
        Origem = origem;
        Destino = destino;
        DataHoraPartida = dataHoraPartida;
        DataHoraChegada = dataHoraChegada;
        AeronaveId = aeronaveId;
        PilotoId = pilotoId;
    }
}
