using System.ComponentModel.DataAnnotations;

namespace EmpresaAPI.Entidades
{
    public class Empleado
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public int RolId { get; set; }     //Se configura automaticamente como una llave foranea
        public Rol Rol { get; set; } = null!;
    }
}
