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
        List<ListarCategoriaDto> dtos = servicoCategoria.SelecionarTodos();
        List<ListarCategoriaViewModel> listarVms = dtos.Select(
            e => new ListarCategoriaViewModel(e.Id, e.Nome, e.Cor))
            .ToList();

        return View(listarVms);
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
        //capta o resultado do servico se foi possivel selecionar por ID
        Result<DetalheCategoriaDto> resultado = servicoCategoria.SelecionarPorId(id);

        if (resultado.IsFailed)
        {
            //caso não pega a mensagem de erro dentro do atributo Erros do objeto RESULT e joga pro tempData
            TempData["MensagemErro"] = resultado.Errors.First().Message;
            return RedirectToAction(nameof(Listar));
        }

        //Aqui sabemos que a conversao deu certo, entao podemos extrair essa variavel
        DetalheCategoriaDto dto = resultado.Value;

        EditarCategoriaViewModel editarVm = new(
            id,
            dto.Nome,
            dto.Cor
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
