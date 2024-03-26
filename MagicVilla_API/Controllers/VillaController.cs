using MagicVilla_API.Data;
using MagicVilla_API.Models;
using MagicVilla_API.Models.DTO;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.JsonPatch;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Linq;

namespace MagicVilla_API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class VillaController : ControllerBase
    {
        private readonly ILogger<VillaController> _logger;
        private readonly ApplicationDbContext _context;

        public VillaController(ILogger<VillaController> logger, ApplicationDbContext context)
        {
            _logger = logger;
            _context = context;

        }

        [HttpGet]
        [ProducesResponseType(StatusCodes.Status200OK)]
        public ActionResult<IEnumerable<VillaDTO>> GetVillas()
        {
            _logger.LogInformation("Obtener villas");
            return Ok(_context.Villas.ToList());
        }

        [HttpGet("{id:int}", Name = "GetVilla")]
        [ProducesResponseType(StatusCodes.Status200OK)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public ActionResult<VillaDTO> GetVilla(int id)
        {
            if (id == 0)
            {
                _logger.LogError("Error al traer la villa ocn id: "+id);
                return BadRequest();
            }
            var villa = _context.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            return Ok(villa);
        }

        [HttpPost]
        [ProducesResponseType(StatusCodes.Status201Created)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status500InternalServerError)]
        public ActionResult<VillaDTO> NewVilla([FromBody] VillaDTO villaDto) 
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (_context.Villas.FirstOrDefault(v => v.Nombre.ToLower() == villaDto.Nombre.ToLower()) != null)
            {
                ModelState.AddModelError("NombreExiste","La villa con ese nombre ya existe");

                return BadRequest(ModelState);
            }

            if (villaDto == null)
            {
                return BadRequest(villaDto);
            }
            if (villaDto.Id > 0)
            {
                return StatusCode(StatusCodes.Status500InternalServerError);
            }

            Villa modelo = new()
            {
                Nombre = villaDto.Nombre,
                Detalle = villaDto.Detalle,
                ImagienUrl = villaDto.ImagienUrl,
                Ocupantes = villaDto.Ocupantes,
                Tarifa = villaDto.Tarifa,
                MetroCuadrados = villaDto.MetrosCuadrados,
                Amenidad = villaDto.Amenidad
            };

            _context.Villas.Add(modelo);
            _context.SaveChanges();

            return CreatedAtRoute("GetVilla", new {id = villaDto.Id}, villaDto);
        }

        [HttpDelete("{id:int}")]
        [ProducesResponseType(StatusCodes.Status204NoContent)]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        [ProducesResponseType(StatusCodes.Status404NotFound)]
        public IActionResult DeleteVilla(int id)
        {
            if (id==0)
            {
                return BadRequest();
            }

            var villa = _context.Villas.FirstOrDefault(v => v.Id == id);

            if (villa == null)
            {
                return NotFound();
            }

            _context.Villas.Remove(villa);
            _context.SaveChanges();

            return NoContent();
        }

        [HttpPut("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdateVilla(int id, [FromBody] VillaDTO villaDTO)
        {
            if (id == 0 || id! != villaDTO.Id) 
            {
                return BadRequest();
            }

            //var villa = VillaStore.VillaList.FirstOrDefault(v => v.Id == id);
            //villa.Nombre = villaDTO.Nombre;
            //villa.Ocupantes = villaDTO.Ocupantes;
            //villa.MetrosCuadrados = villaDTO.MetrosCuadrados;

            Villa modelo = new()
            {
                Id = villaDTO.Id,
                Nombre = villaDTO.Nombre,
                Detalle = villaDTO.Detalle,
                ImagienUrl = villaDTO.ImagienUrl,
                Ocupantes = villaDTO.Ocupantes,
                Tarifa = villaDTO.Tarifa,
                MetroCuadrados = villaDTO.MetrosCuadrados,
                Amenidad = villaDTO.Amenidad
            };

            _context.Villas.Update(modelo);
            _context.SaveChanges();

            return Ok(modelo);
        }

        [HttpPatch("{id:int}")]
        [ProducesResponseType(StatusCodes.Status400BadRequest)]
        public IActionResult UpdatePartialVilla(int id, JsonPatchDocument<VillaDTO> patchDTO)
        {
            if (id == 0 || patchDTO == null)
            {
                return BadRequest();
            }

            var villa = _context.Villas.AsNoTracking().FirstOrDefault(v => v.Id == id);

            VillaDTO dto = new()
            {
                Id = villa.Id,
                Nombre = villa.Nombre,
                Detalle = villa.Detalle,
                ImagienUrl = villa.ImagienUrl,
                Ocupantes = villa.Ocupantes,
                Tarifa = villa.Tarifa,
                MetrosCuadrados = villa.MetroCuadrados,
                Amenidad = villa.Amenidad
            };

            if (villa == null) 
            {
                return BadRequest();
            }

            patchDTO.ApplyTo(dto, ModelState);

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            Villa modelo = new()
            {
                Id = dto.Id,
                Nombre = dto.Nombre,
                Detalle = dto.Detalle,
                ImagienUrl = dto.ImagienUrl,
                Ocupantes = dto.Ocupantes,
                Tarifa = dto.Tarifa,
                MetroCuadrados = dto.MetrosCuadrados,
                Amenidad = dto.Amenidad
            };

            _context.Villas.Update(modelo);

            _context.SaveChanges();

            return Ok(villa);
        }
    }
}
