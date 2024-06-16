namespace WebApp.Models
{
    public class Juez
    {
        public int Id { get; }
        public string Nombre { get; }
        public LinkedList<Puntuacion> Puntuaciones { get; }

        public Juez(int id, string nombre, LinkedList<Puntuacion> puntuaciones)
        {
            Id = id;
            Nombre = nombre;
            Puntuaciones = puntuaciones;
        }
    }
}