namespace WebApp.Models;

public class PuntuacionSaltos: Puntuacion, IPuntuacion
{
    public PuntuacionSaltos(Atleta atleta) : base(atleta) {}

    public int CalcularPuntaje()
    {
        throw new NotImplementedException();
    }
}