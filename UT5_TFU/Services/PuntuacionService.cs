using WebApp.Models;

namespace WebApp.Services
{
    public class PuntuacionService
    {
        public void InitializePuntuacion(Puntuacion model)
        {
            if (model.Atletaa == null)
            {
                model.Atletaa = new Atleta();
            }
        }
    }
}