namespace Valorant.Models;

public class Agente
{
    public int Numero { get; set; }
    public string Nome { get; set; }
    public string Descricao { get; set; }
    public List<string> Classe { get; set; }
    public string Imagem { get; set; }

    public Agente()
    {
        Classe = new List<string>();
    }
}
