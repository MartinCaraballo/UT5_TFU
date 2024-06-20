namespace WebApp.Models
{
    public class Juez : Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Puntuacion> Puntuaciones { get; set; }

        public Juez(int id, string nombre) : base (id, nombre)
        {
            Id = id;
            Nombre = nombre;
            Puntuaciones = new List<Puntuacion>();
        }
    }
}