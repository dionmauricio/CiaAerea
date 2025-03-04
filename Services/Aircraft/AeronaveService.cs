using CiaAerea.Contexts;
using CiaAerea.Entities.Aircraft;
using CiaAerea.ViewModels.Aircraft;

namespace CiaAerea.Services.Aircraft;

public class AeronaveService
{
    private readonly CiaAereaContext _context;

    public AeronaveService(CiaAereaContext context)
    {
        _context = context;
    }

    public DetalhesAeronaveViewModel AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        var aeronave = new Aeronave(
            dados.Fabricante,
            dados.Modelo,
            dados.Codigo);

        _context.Add(aeronave);
        _context.SaveChanges();

        return new DetalhesAeronaveViewModel(
            aeronave.Id,
            aeronave.Fabricante,
            aeronave.Modelo,
            aeronave.Codigo);
    }
}
