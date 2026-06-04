using Microsoft.AspNetCore.Mvc;

namespace ClubeDaLeituraWeb.WebApp.ModuloProduto.Apresentacao.Views;

public class ProdutoController : Controller
{
    public ActionResult Listar()
    {
        return View();
    }
}
