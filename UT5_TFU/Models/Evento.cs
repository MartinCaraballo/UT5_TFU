namespace WebApp.Models
{
    public class Evento
    {
        public int Id { get; set; }
        public LinkedList<Puntuacion> Puntuaciones { get; set; }

        public Evento(int id)
        {
            Id = id;
            Puntuaciones = new LinkedList<Puntuacion>();
        }
    }
}