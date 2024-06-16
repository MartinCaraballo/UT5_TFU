namespace WebApp.Models
{
    public class Evento
    {
        public int Id { get; }
        public LinkedList<Puntuacion> Puntuaciones { get; }

        public Evento(int id, LinkedList<Puntuacion> puntuaciones)
        {
            Id = id;
            Puntuaciones = puntuaciones;
        }
    }
}