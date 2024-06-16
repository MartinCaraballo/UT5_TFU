using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class AtletaRepository
    {
        private DataContext _context;

        public AtletaRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Atleta> GetAtletas()
        {
            return _context.Atletas.ToList();
        }

        public Atleta GetAtleta(int id)
        {
            return _context.Atletas.Where(a => a.Id == id).FirstOrDefault();
        }

        public bool CreateAtleta(Atleta atleta)
        {
            _context.Add(atleta);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}