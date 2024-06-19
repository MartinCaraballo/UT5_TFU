namespace WebApp.Models
{
    public class Juez : Usuario
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Puntuacion> Puntuaciones { get; set; }

    }
}