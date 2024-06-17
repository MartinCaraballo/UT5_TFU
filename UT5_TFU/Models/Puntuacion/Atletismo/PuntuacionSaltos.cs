namespace WebApp.Models;

public class PuntuacionSaltos : Puntuacion, IPuntuacion
{
    public int Distancia { get; set; }
    public int Tiempo { get; set; }

    public PuntuacionSaltos(Atleta atleta, int distancia, int tiempo) : base(atleta)
    {
        Distancia = distancia;
        Tiempo = tiempo;
    }

    public int CalcularPuntaje()
    {
        throw new NotImplementedException();
    }
}