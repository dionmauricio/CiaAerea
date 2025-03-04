using CiaAerea.Services.Aircraft;
using CiaAerea.ViewModels.Aircraft;
using Microsoft.AspNetCore.Mvc;

namespace CiaAerea.Controllers.Aircraft;

[Route("api/v1/aeronaves")]
[ApiController]
public class AeronaveController : ControllerBase
{
    private readonly AeronaveService _aeronaveService;

    public AeronaveController(AeronaveService aeronaveService)
    {
        _aeronaveService = aeronaveService;
    }

    [HttpPost]
    public IActionResult AdicionarAeronave(AdicionarAeronaveViewModel dados)
    {
        var aeronave = _aeronaveService.AdicionarAeronave(dados);

        return Ok(aeronave);
    }
}