using WebApp.Models;

namespace WebApp.Services
{
    public class EventoService
    {
        public void InitializeEvento(Evento model)
        {
            if (model.Puntuaciones == null)
            {
                model.Puntuaciones = new List<Puntuacion>();
            }

            foreach (var puntuacion in model.Puntuaciones)
            {
                if (puntuacion.Atletaa == null)
                {
                    puntuacion.Atletaa = new Atleta();
                }
            
            }
        }
    }
}