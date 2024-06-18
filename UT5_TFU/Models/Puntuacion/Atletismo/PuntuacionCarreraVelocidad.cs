namespace WebApp.Models;

public class PuntuacionCarreraVelocidad : Puntuacion, IPuntuacion
{
    public int Distancia { get; set; }
    public int Tiempo { get; set; }

    public int CalcularPuntaje()
    {
        throw new NotImplementedException();
    }
}