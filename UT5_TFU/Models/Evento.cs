namespace WebApp.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public ICollection<Puntuacion> Puntuaciones { get; set; }

    }
}