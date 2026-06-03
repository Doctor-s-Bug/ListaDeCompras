using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao;

public class CategoriaController : Controller
{
    [HttpGet]
    public ActionResult Listar()
    {
        return View();
    }
}
