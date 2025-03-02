namespace CiaAerea.Entities.Pilots;

public class Piloto
{
    public Piloto(string nomeCompleto, string matricula)
    {
        NomeCompleto = nomeCompleto;
        Matricula = matricula;
    }

    public int Id { get; set; }
    public string NomeCompleto { get; set; }
    public string Matricula { get; set; }
}
