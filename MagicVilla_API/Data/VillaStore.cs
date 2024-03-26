using MagicVilla_API.Models.DTO;

namespace MagicVilla_API.Data
{
    public static class VillaStore
    {
        public static List<VillaDTO> VillaList = new List<VillaDTO>()
        {
            new VillaDTO { Id = 1, Nombre = "Vista a la Piscina", Ocupantes=3, MetrosCuadrados= 50},
            new VillaDTO { Id = 2, Nombre = "Vista a la Playa", Ocupantes=2, MetrosCuadrados=80 },
        };       
    }
}
