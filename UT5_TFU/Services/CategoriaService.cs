using WebApp.Models;

namespace WebApp.Services
{
    public class CategoriaService
    {
        public void InitializeCategoria(Categoria model)
        {
            if (model.Eventos == null)
            {
                model.Eventos = new List<Evento>();
            }

            foreach (var evento in model.Eventos)
            {
                if (evento.Puntuaciones == null)
                {
                    evento.Puntuaciones = new List<Puntuacion>();
                }

                foreach (var puntuacion in evento.Puntuaciones)
                {
                    if (puntuacion.Atletaa == null)
                    {
                        puntuacion.Atletaa = new Atleta();
                    }
                }
            }
        }
    }
}