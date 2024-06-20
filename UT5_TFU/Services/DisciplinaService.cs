using WebApp.Models;

namespace WebApp.Services
{
    public class DisciplinaService
    {
        public void InitializeDisciplina(Disciplina model)
        {
            if (model.Modalidades == null)
            {
                model.Modalidades = new List<Modalidad>();
            }

            foreach (var modalidad in model.Modalidades)
            {
                if (modalidad.Categorias == null)
                {
                    modalidad.Categorias = new List<Categoria>();
                }

                foreach (var categoria in modalidad.Categorias)
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
}