namespace WebApp.Models
{
    public abstract class Puntuacion : IPuntuacion
    {
        public Atleta Atleta { get; }
        public int Puntaje { get; }

        public Puntuacion(Atleta atleta)
        {
            Atleta = atleta;
            Puntaje = 0;
        }

        public abstract override int CalcularPuntaje();
    }
}