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
                var atletas = new List<Atleta>()
                {
                    new Atleta() { Nombre = "Javier", FechaNac = new DateTime(2001, 12, 3), Sexo = "Masculino"},
                    new Atleta() { Nombre = "Pedro", FechaNac = new DateTime(2002, 12, 3), Sexo = "Masculino"},
                    new Atleta() { Nombre = "Juan", FechaNac = new DateTime(2003, 12, 3), Sexo = "Masculino"}
                };
                dataContext.Atletas.AddRange(atletas);
                var evento = new Evento() {
                    Puntuaciones = new List<Puntuacion>() {
                        new PuntuacionCarreraPista() {
                            Atletaa = new Atleta() { Nombre = "Javier", FechaNac = new DateTime(2001, 12, 03), Sexo = "Masculino"}
                        }
                    }
                };
                dataContext.AddRange(evento);
                dataContext.SaveChanges();
            }
        }
    }
}
