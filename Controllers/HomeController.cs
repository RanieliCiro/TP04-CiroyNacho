using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using TP04.Models;

namespace TP04.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        Juego.iniciarJuego();
        return View();
    }
    public IActionResult Jugar()
    {   
        ViewBag.palabraParcial=Juego.getPalabraParcial();
        ViewBag.usadas=Juego.usadas;
        ViewBag.intentos=Juego.intentos;
        ViewBag.cantLetrasPalabra=Juego.palabraParcial.Length;
        if(Juego.termino){
            if(Juego.gano){
                return RedirectToAction("Win");
            }
            else{
                return RedirectToAction("Lose");
            }
        }
        return View("Jugar");
    }
    public IActionResult ArriesgarLetra(string Larriesgada)
    {
        Juego.ArriesgarLetra(Larriesgada[0]);
        return RedirectToAction("Jugar");
    }
    public IActionResult ArriesgarPalabra(string Parriesgada)
    {
        Juego.ArriesgarPalabra(Parriesgada);
        return RedirectToAction("Jugar");
    }
    public IActionResult Win()
    {
        ViewBag.palabra=Juego.palabra;
        return View("Win");
    }
    public IActionResult Lose()
    {
        ViewBag.palabra=Juego.palabra;
        return View("Lose");
    }
}