using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Repositorio.IRepositorio;

namespace MagicVilla_API.Repositorio
{
    public class NumeroVillaRepositorio : Repositorio<NumeroVilla>, INumeroVillaRepositorio
    {
        private readonly ApplicationDbContext _contexto;

        public NumeroVillaRepositorio(ApplicationDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<NumeroVilla> Actualizar(NumeroVilla entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;

            _contexto.NumeroVillas.Update(entidad);
            await _contexto.SaveChangesAsync();

            return entidad;
        }
    }
}
