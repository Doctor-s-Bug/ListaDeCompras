using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using Microsoft.AspNetCore.Mvc;
using static ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao.CategoriaViewModels;

namespace ClubeDaLeituraWeb.WebApp.ModuloCategoria.Apresentacao;

public class CategoriaController : Controller
{
    private readonly ServicoCategoria servicoCategoria;
    private readonly IRepositorioCategoria repositorioCategoria;

    public CategoriaController(ServicoCategoria servicoCategoria, IRepositorioCategoria repositorioCategoria)
    {
        this.servicoCategoria = servicoCategoria;
        this.repositorioCategoria = repositorioCategoria;
    }

    [HttpGet]
    public ActionResult Listar()
    {
        List<Categoria> categorias = repositorioCategoria.SelecionarTodos();

        List<ListarCategoriaViewModel> listarVm = new();

        foreach (Categoria categoria in categorias)
        {
            ListarCategoriaViewModel vm = new(
                categoria.Id,
                categoria.Nome,
                categoria.Cor
            );
            listarVm.Add(vm);
        }
        return View(listarVm);
    }
    public ActionResult Cadastrar()
    {
        return View();
    }
    [HttpPost]
    public ActionResult Cadastrar(CadastrarCategoriaViewModel c)
    {
        if (!ModelState.IsValid)
            return View(c);

        Categoria novaCategoria = new(
            c.Nome,
            c.Cor
        );

        repositorioCategoria.Cadastrar(novaCategoria);

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Excluir(string Id)
    {
        Categoria? c = repositorioCategoria.SelecionarPorId(Id);

        if (c == null)
            return RedirectToAction(nameof(Listar));

        ExcluirCategoriaViewModel excluirVm = new(
            c.Id,
            c.Nome,
            c.Cor
        );

        return View(excluirVm);
    }
    [HttpPost]
    public ActionResult Excluir(ExcluirCategoriaViewModel e)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(e.Id);

        if (categoria != null)
            repositorioCategoria.Excluir(e.Id);

        return RedirectToAction(nameof(Listar));
    }
    public ActionResult Editar(string id)
    {
        Categoria? categoria = repositorioCategoria.SelecionarPorId(id);

        if (categoria == null)
            return RedirectToAction(nameof(Listar));

        EditarCategoriaViewModel editarVm = new(
            id,
            categoria.Nome,
            categoria.Cor
        );
        return View(editarVm);
    }
    [HttpPost]
    public ActionResult Editar(EditarCategoriaViewModel e)
    {
        if (!ModelState.IsValid)
            return View(e);

        Categoria categoriaAtualizada = new(
            e.Nome,
            e.Cor
        );
        repositorioCategoria.Editar(e.Id, categoriaAtualizada);

        return RedirectToAction(nameof(Listar));
    }
}
