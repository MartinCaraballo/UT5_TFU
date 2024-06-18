namespace WebApp.Models
{
    public abstract class Puntuacion
    {
        public int Id { get; set; }
        public Atleta Atletaa { get; set; }
        public int Puntaje { get; set; }

    }
}