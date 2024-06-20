namespace WebApp.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public ICollection<Puntuacion> Puntuaciones { get; set; }

        public Evento(int id)
        {
            Id = id;
            Puntuaciones = new List<Puntuacion>();
        }

    }
}