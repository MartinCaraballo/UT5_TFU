namespace WebApp.Models
{
    public abstract class Puntuacion
    {
        public Atleta Atleta { get; set; }
        public int Puntaje { get; set; }

        public Puntuacion(Atleta atleta)
        {
            Atleta = atleta;
            Puntaje = 0;
        }
    }
}