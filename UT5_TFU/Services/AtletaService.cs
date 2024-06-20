using System.Collections.Generic;
using System.Linq;
using WebApp.Models;
using WebApp.Data;

namespace WebApp.Services
{
    public class AtletaService
    {
        private readonly DataContext _context;

        public AtletaService(DataContext context)
        {
            _context = context;
        }

        public IEnumerable<Atleta> GetAtletas()
        {
            return _context.Atletas.ToList();
        }

        public Atleta GetAtleta(int id)
        {
            return _context.Atletas.Find(id);
        }

        public bool CreateAtleta(Atleta atleta)
        {
            _context.Atletas.Add(atleta);
            return _context.SaveChanges() > 0;
        }
    }
}
