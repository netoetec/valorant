namespace Valorant.Models;

public class DetailsVM
{
    public Agente Anterior { get; set; }
    public Agente Atual { get; set; }
    public Agente Proximo { get; set; }
    public List<Classe> Classes { get; set; }
}