using Karellen.Data.Contexto;
using Karellen.Data.Interface.Repositorio;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace Karellen.Data.Infraestrutura.Repositorio
{
    internal class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly KarellenContexto _contexto;
        private readonly DbSet<T> _set;

        public DbSet<T> Set
        {
            get { return _set ?? _contexto.Set<T>(); }
        }


        public Repositorio(KarellenContexto contexto)
        {
            _contexto = contexto;
            _set = contexto.Set<T>();
        }

        public List<T> Buscar(Func<T, bool> predicado)
        {
            return Set.Where(predicado).ToList();
        }

        public List<T> BuscarTodos()
        {
            return Set.ToList();
        }

        public Task<List<T>> BuscarTodosAsync()
        {
            return Set.ToListAsync();
        }

        public Task<List<T>> BuscarTodosAsync(CancellationToken token)
        {
            return Set.ToListAsync(token);
        }

        public List<T> BuscarPaginado(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToList();
        }

        public Task<List<T>> BuscarPaginadoAsync(int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync();
        }

        public Task<List<T>> BuscarPaginado(CancellationToken token, int skip, int take)
        {
            return Set.Skip(skip).Take(take).ToListAsync(token);
        }

        public T BuscarPorId(object id)
        {
            return Set.Find(id);
        }

        public Task<T> BuscarPorIdAsync(object id)
        {
            return Set.FindAsync(id);
        }

        public Task<T> BuscarPorIdAsync(CancellationToken cancellationToken, object id)
        {
            return Set.FindAsync(cancellationToken, id);
        }

        public void Adicionar(T entidade)
        {
            Set.Add(entidade);
        }

        public void Atualizar(T entidade)
        {
            var entry = _contexto.Entry(entidade);
            if (entry.State == EntityState.Detached)
            {
                Set.Attach(entidade);
                entry = _contexto.Entry(entidade);
            }
            entry.State = EntityState.Modified;
        }

        public void Remover(T entidade)
        {
            DbEntityEntry dbEntityEntry = _contexto.Entry<T>(entidade);
            if (dbEntityEntry.State != EntityState.Detached)
            {
                dbEntityEntry.State = EntityState.Deleted;
            }
            else
            {
                Set.Attach(entidade);
                Set.Remove(entidade);
            }
        }
    }
}
