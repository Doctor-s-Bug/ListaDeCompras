
using System.Linq.Expressions;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Dominio;
using ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Orm;
using Microsoft.EntityFrameworkCore;

namespace ClubeDaLeituraWeb.WebApp.Compartilhado.Infra.Compartilhado;

public abstract class RepositorioBaseEmOrm<T>(ListaDeComprasDbContext dbContext) where T : EntidadeBase<T>
{
    protected readonly DbSet<T> registros = dbContext.Set<T>();

    public void Cadastrar(T entidade)
    {
        registros.Add(entidade);

        dbContext.SaveChanges(); // commit
    }

    public bool Editar(string idSelecionado, T entidadeAtualizada)
    {
        T? registroSelecionado = SelecionarPorId(idSelecionado);

        if (registroSelecionado == null)
            return false;

        registroSelecionado.Atualizar(entidadeAtualizada);

        dbContext.SaveChanges();

        return true;
    }

    public bool Excluir(string idSelecionado)
    {
        T? TSelecionado = SelecionarPorId(idSelecionado);

        if (TSelecionado == null)
            return false;

        registros.Remove(TSelecionado);

        dbContext.SaveChanges();

        return true;
    }

    public virtual T? SelecionarPorId(string idSelecionado)
    {
        return registros.SingleOrDefault(c => c.Id == idSelecionado);
    }

    public virtual List<T> SelecionarTodos()
    {
        return registros.ToList();
    }
    public virtual List<T> Filtrar(Expression<Func<T, bool>> filtro)
    {
        return registros.Where(filtro).ToList();
    }
}