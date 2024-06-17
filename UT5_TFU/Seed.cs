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
                    new Atleta(1, "Javier", new DateTime(2001, 12, 3), "Masculino"),
                    new Atleta(2, "Pedro", new DateTime(2002, 12, 3), "Masculino"),
                    new Atleta(3, "Juan", new DateTime(2003, 12, 3), "Masculino")
                };
                dataContext.Atletas.AddRange(atletas);
                dataContext.SaveChanges();
            }
        }
    }
}
