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
        Juego.inicializarJuego();
        return View();
    }
    public IActionResult Jugar()
    {   
        ViewBag.palabraParcial=Juego.getPalabraParcial();
        ViewBag.usadas=Juego.getLetrasUsadas();
        ViewBag.intentos=Juego.getIntentos();
        ViewBag.termino=Juego.Termino();
        ViewBag.gano=Juego.Gano();

        if(Juego.Termino()){
            if(Juego.Gano()){
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
        ViewBag.palabra=Juego.getPalabra();
        return View("Win");
    }
    public IActionResult Lose()
    {
        ViewBag.palabra=Juego.getPalabra();
        return View("Lose");
    }
}