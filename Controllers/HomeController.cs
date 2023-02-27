using Microsoft.AspNetCore.Mvc;

namespace App.Controllers;

public class HomeController : Controller
{
    public IActionResult Index()
    {
        ViewBag.Subtitulo = "Página Principal";
        return View();
    }

    public IActionResult Portifolio()
    {
        ViewBag.Subtitulo = "Página Portifólio";
        return View();
    }

    public IActionResult Sobre()
    {
        ViewBag.Subtitulo = "Página Sobre";
        return View();
    }
}