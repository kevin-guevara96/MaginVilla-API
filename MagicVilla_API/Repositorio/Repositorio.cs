using MagicVilla_API.Data;
using MagicVilla_API.Repositorio.IRepositorio;
using Microsoft.EntityFrameworkCore;
using System.Linq.Expressions;

namespace MagicVilla_API.Repositorio
{
    public class Repositorio<T> : IRepositorio<T> where T : class
    {
        private readonly ApplicationDbContext _contexto;
        internal DbSet<T> _dbset;

        public Repositorio(ApplicationDbContext contexto)
        {
            _contexto = contexto;
            this._dbset = _contexto.Set<T>();
        }

        public async Task Crear(T entidad)
        {
            await _contexto.AddAsync(entidad);
            await Grabar();
        }

        public async Task Grabar()
        {
            await _contexto.SaveChangesAsync();
        }

        public async Task<T> Obtener(Expression<Func<T, bool>>? filtro = null, bool tracked = true)
        {
            IQueryable<T> query = _dbset;

            if (!tracked)
            {
                query = query.AsNoTracking();
            }

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.FirstOrDefaultAsync();
        }

        public async Task<List<T>> ObtenerTodos(Expression<Func<T, bool>>? filtro = null)
        {
            IQueryable<T> query = _dbset;

            if (filtro != null)
            {
                query = query.Where(filtro);
            }

            return await query.ToListAsync();
        }

        public async Task Remover(T entidad)
        {
            _dbset.Remove(entidad);
            await Grabar();
        }
    }
}
