using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Repositorio.IRepositorio;

namespace MagicVilla_API.Repositorio
{
    public class VillaRepositorio : Repositorio<Villa>, IVillaRepositorio
    {
        private readonly ApplicationDbContext _contexto;

        public VillaRepositorio(ApplicationDbContext contexto) : base(contexto)
        {
            _contexto = contexto;
        }

        public async Task<Villa> Actualizar(Villa entidad)
        {
            entidad.FechaActualizacion = DateTime.Now;

            _contexto.Villas.Update(entidad);
            await _contexto.SaveChangesAsync();

            return entidad;
        }
    }
}
