namespace WebApp.Models
{
    public class Juez
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public LinkedList<Puntuacion> Puntuaciones { get; set; }

    }
}