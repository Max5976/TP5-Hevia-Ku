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

    public IActionResult Index()
    {
        return View();
    }
    public IActionResult Intro(string nuevoNombre)
    {
        HttpContext.Session.SetString("nombre", nuevoNombre);
        return View();
    }
    public IActionResult Historia() {
        ViewBag.nombre = HttpContext.Session.GetString("nombre");
        return View();
    }
}
