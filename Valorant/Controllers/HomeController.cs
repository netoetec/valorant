using System.Diagnostics;
using System.Text.Json;
using Microsoft.AspNetCore.Mvc;
using Valorant.Models;

namespace Valorant.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        List<Agente> agentes = GetAgentes();
        List<Classe> classes = GetClasses();
        ViewData["Classes"] = classes;
        return View(agentes);
    }

    public IActionResult Details(int id)
    {
        List<Agente> agentes = GetAgentes();
        List<Classe> classes = GetClasses();
        DetailsVM details = new() {
            Classes = classes,
            Atual = agentes.FirstOrDefault(a => a.Numero == id),
            Anterior = agentes.OrderByDescending(a => a.Numero).FirstOrDefault(a => a.Numero < id),
            Proximo = agentes.OrderBy(a => a.Numero).FirstOrDefault(a => a.Numero > id),
        };
        return View(details);
    }

    private List<Agente> GetAgentes()
    {
        using (StreamReader leitor = new("Data\\agentes.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Agente>>(dados);
        }
    }

        private List<Classe> GetClasses()
    {
        using (StreamReader leitor = new("Data\\classes.json"))
        {
            string dados = leitor.ReadToEnd();
            return JsonSerializer.Deserialize<List<Classe>>(dados);
        }
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}