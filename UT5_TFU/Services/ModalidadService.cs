using System.Collections.Generic;
using WebApp.Models;

namespace WebApp.Services
{
    public class ModalidadService
    {
        public void InitializeModalidad(Modalidad model)
        {
            if (model.Categorias == null)
            {
                model.Categorias = new List<Categoria>();
            }

            foreach (var categoria in model.Categorias)
            {
                if (categoria.Eventos == null)
                {
                    categoria.Eventos = new List<Evento>();
                }

                foreach (var evento in categoria.Eventos)
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
}
