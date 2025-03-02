using CiaAerea.Entities.Aircraft;
using CiaAerea.Entities.Enums;

namespace CiaAerea.Entities.Maintenance;

public class Manutencao
{
    public Manutencao(DateTime dataHora, TipoManutencaoEnum tipo, int aeronaveId, string observacao = "Não há observações.")
    {
        DataHora = dataHora;
        Observacao = observacao;
        Tipo = tipo;
        AeronaveId = aeronaveId;
    }

    public int Id { get; set; }
    public DateTime DataHora { get; set; }
    public string Observacao { get; set; }
    public TipoManutencaoEnum Tipo { get; set; }
    public int AeronaveId { get; set; }
    public Aeronave Aeronave { get; set; } = null!;
}
