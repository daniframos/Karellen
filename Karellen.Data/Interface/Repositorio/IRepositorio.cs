using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Interface.Repositorio
{
    public interface IRepositorio<TEntidade> where TEntidade: class
    {
        List<TEntidade> Buscar(Func<TEntidade, bool> predicado);

        List<TEntidade> BuscarTodos();
        Task<List<TEntidade>> BuscarTodosAsync();
        Task<List<TEntidade>> BuscarTodosAsync(CancellationToken token);

        List<TEntidade> BuscarPaginado(int skip, int take);
        Task<List<TEntidade>> BuscarPaginadoAsync(int skip, int take);
        Task<List<TEntidade>> BuscarPaginado(CancellationToken token, int skip, int take);

        TEntidade BuscarPorId(object id);
        Task<TEntidade> BuscarPorIdAsync(object id);
        Task<TEntidade> BuscarPorIdAsync(CancellationToken cancellationToken, object id);

        void Adicionar(TEntidade entidade);
        void Atualizar(TEntidade entidade);
        void Remover(TEntidade entidade);
    }
}
