using System.ComponentModel.DataAnnotations;

namespace EmpresaAPI.DTOs
{
    public class SectorCreacionDTO
    {

        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        
    }
}
