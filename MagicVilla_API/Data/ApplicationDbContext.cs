using MagicVilla_API.Models;
using MagicVilla_API.Models.DTO;
using Microsoft.EntityFrameworkCore;

namespace MagicVilla_API.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) 
            : base(options)
        {
            
        }

        public DbSet<Villa> Villas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Villa>().ToTable("Villa").HasData(
                new Villa
                {
                    Id = 1,
                    Nombre = "Villa Real",
                    Detalle = "Detalle de la Villa...",
                    ImagienUrl = "",
                    Ocupantes = 5,
                    MetroCuadrados = 50,
                    Tarifa = 200,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                },
                new Villa
                {
                    Id = 2,
                    Nombre = "Premium Vista a la Piscina",
                    Detalle = "Detalle de la Villa...",
                    ImagienUrl = "",
                    Ocupantes = 4,
                    MetroCuadrados = 40,
                    Tarifa = 150,
                    Amenidad = "",
                    FechaCreacion = DateTime.Now,
                    FechaActualizacion = DateTime.Now,
                }
                );
        }
    }
}
