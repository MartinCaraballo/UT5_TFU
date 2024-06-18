using System;
using WebApp.Data;
using WebApp.Models;

namespace WebApp
{
    public class Seed
    {
        private readonly DataContext dataContext;
        public Seed(DataContext context)
        {
            this.dataContext = context;
        }
        public void SeedDataContext()
        {
            if (!dataContext.Atletas.Any())
            {
                var disciplinas = new List<Disciplina>()
                {
                    new Disciplina() {
                        Nombre = "Atletismo",
                        Modalidades = new List<Modalidad>() {
                            new Modalidad() {
                                Nombre = "Carrera Pista",
                                Categorias = new List<Categoria>() {
                                    new Categoria() {
                                        Nombre = "N/A",
                                        Eventos = new List<Evento>() {
                                            new Evento() {
                                                Puntuaciones = new List<Puntuacion>() {
                                                    new PuntuacionCarreraPista() {
                                                    Atletaa = new Atleta() {
                                                        Nombre = "Jose", FechaNac = new DateTime(2000, 12, 03), Sexo = "Masculino"}
                                                    }
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                };
                dataContext.Disciplinas.AddRange(disciplinas);

                var atletas = new List<Atleta>()
                {
                    new Atleta() { Nombre = "Javier", FechaNac = new DateTime(2001, 12, 3), Sexo = "Masculino"},
                    new Atleta() { Nombre = "Pedro", FechaNac = new DateTime(2002, 12, 3), Sexo = "Masculino"},
                    new Atleta() { Nombre = "Juan", FechaNac = new DateTime(2003, 12, 3), Sexo = "Masculino"}
                };
                dataContext.Atletas.AddRange(atletas);

                dataContext.SaveChanges();
            }
        }
    }
}
