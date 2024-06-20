using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class ModalidadRepository
    {
        private DataContext _context;

        public ModalidadRepository(DataContext context)
        {
            _context = context;
        }

        public List<Modalidad> GetModalidades()
        {
            return _context.Modalidades.ToList();
        }

        public Modalidad GetModalidad(int id)
        {
            return _context.Modalidades.Where(a => a.Id == id).FirstOrDefault();
        }

        public bool CreateModalidad(Modalidad modalidad)
        {
            _context.Add(modalidad);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}