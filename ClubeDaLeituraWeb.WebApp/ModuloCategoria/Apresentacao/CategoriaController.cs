using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Aplicacao;
using ClubeDaLeituraWeb.WebApp.ModuloCategoria.Dominio;
using FluentResults;
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
    public ActionResult Cadastrar(CadastrarCategoriaViewModel cadastrarVm)
    {
        if (!ModelState.IsValid)
            return View(cadastrarVm);

        CadastrarCategoriaDto dto = new(
            cadastrarVm.Nome,
            cadastrarVm.Cor
        );

        Result resultado = servicoCategoria.Cadastrar(dto);

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
            {
                string campo = erro.Metadata["Campo"] is string ? erro.Metadata["Campo"].ToString()! : string.Empty;

                ModelState.AddModelError(campo, erro.Message);
            }
            return View(cadastrarVm);
        }

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
    public ActionResult Excluir(ExcluirCategoriaViewModel e) //aula 64 - nao poder excluir categorias vinculadas a produto - 1,55seg
    {
        Result resultado = servicoCategoria.Excluir(e.Id);

        if (resultado.IsFailed)
        {
            TempData["MensagemErro"] = resultado.Errors.First().Message;
        }
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
    public ActionResult Editar(EditarCategoriaViewModel editarVm)
    {
        if (!ModelState.IsValid)
            return View(editarVm);

        Result resultado = servicoCategoria.Editar(new EditarCategoriaDto(editarVm.Id, editarVm.Nome, editarVm.Cor));

        if (resultado.IsFailed)
        {
            foreach (IError erro in resultado.Errors)
            {
                string campo = erro.Metadata["Campo"] is string ? erro.Metadata["Campo"].ToString()! : string.Empty;

                ModelState.AddModelError(campo, erro.Message);
            }

            return View(editarVm);
        }

        return RedirectToAction(nameof(Listar));
    }
}
