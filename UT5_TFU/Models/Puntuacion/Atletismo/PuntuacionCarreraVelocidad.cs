namespace WebApp.Models;

public class PuntuacionCarreraVelocidad: Puntuacion, IPuntuacion
{
    public PuntuacionCarreraVelocidad(Atleta atleta) : base(atleta) {}

    public int CalcularPuntaje()
    {
        throw new NotImplementedException();
    }
}