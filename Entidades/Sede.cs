namespace EmpresaAPI.Entidades
{
    public class Sede
    {
        public int Id { get; set; }
        public string Ubicacion { get; set; } = null!;
        public DateTime FechaInauguracion { get; set; }
        // public HashSet<Sector> Sectores { get; set; } = new HashSet<Sector>(); //Rel n:n
    }
}
