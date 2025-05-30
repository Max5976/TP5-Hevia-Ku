using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP5_Hevia_Ku.Models;
using Newtonsoft.Json;

namespace TP5_Hevia_Ku.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

   public class HomeController : Controller
    {
        private const string MapSessionKey = "_MapState"; 

        public IActionResult Index()
        {
            return View("Index"); 
        }
        [HttpPost]
        public IActionResult ResolveRoom(int roomId)
        {
            Sala currentSala = Objeto.StringToObject<Sala>(HttpContext.Session.GetString(MapSessionKey));

            if (currentSala != null)
            {
                Room roomToUnlock = currentSala.Rooms.FirstOrDefault(r => r.Id == roomId);

                if (roomToUnlock != null && !roomToUnlock.IsUnlocked)
                {
                    roomToUnlock.IsUnlocked = true;
                    HttpContext.Session.SetString(MapSessionKey, Objeto.ObjectToString(currentSala));
                }
            }
            return RedirectToAction("Index");
        }

        public IActionResult ResetMap()
        {
            HttpContext.Session.Remove(MapSessionKey);
            return RedirectToAction("Index");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
    
    public IActionResulta IngresarNombre() 
    {
        return View("Presentacion/IngresarNombre");
    }
    public IActionResult Intro(string nuevoNombre)
    {
        HttpContext.Session.SetString("nombre", nuevoNombre);
        return View("Presentacion/Intro");
    }
    public IActionResult Historia() 
    {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("Presentacion/Historia");
    }
    public IActionResult PrimerCuarto() 
    {
        ViewBag.segs = 300;
        return View("SalaI/PrimerCuarto");
    }
    public IActionResult Perdiste() 
    {
        return View();
    }
    public IActionResult HistoriaII()
    {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View("SalaI/HistoriaII");
    }
    public IActionResult VerificarCodigo(string codigo) 
    {
        if (codigo == "SATOIA") {
            return View("SalaI/HistoriaIII");
        }
        else {
            return View("SalaI/Error");
        }
    }
}
