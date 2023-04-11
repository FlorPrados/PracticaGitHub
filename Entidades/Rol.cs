namespace EmpresaAPI.Entidades
{
    public class Rol
    {
        public int Id { get; set; }
        public string Nombre { get; set; } = null!;
        public decimal Salario { get; set; }
        public HashSet<Empleado> Empleados { get; set; } = new HashSet<Empleado>(); //Rel n:1  (Empleados:Rol)
    }
}
