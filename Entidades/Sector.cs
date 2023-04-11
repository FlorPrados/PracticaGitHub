using System.ComponentModel.DataAnnotations;

namespace EmpresaAPI.Entidades
{
    public class Sector
    {
        public int Id { get; set; }

        [StringLength(maximumLength: 150)]
        public string Nombre { get; set; } = null!;
        public string Descripcion { get; set; } = null!;
        //public HashSet<Rol> Roles { get; set; } = new HashSet<Rol>();  //Rel n:1  (Roles:Sector)
        // public HashSet<Sede> Sedes { get; set; } = new HashSet<Sede>();  //Rel n:n

    }
}
