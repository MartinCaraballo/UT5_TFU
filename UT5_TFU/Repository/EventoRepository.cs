using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class EventoRepository
    {
        private DataContext _context;

        public EventoRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Evento> GetEventos()
        {
            return _context.Eventos.ToList();
        }

        public Evento GetEvento(int id)
        {
            return _context.Eventos.Where(a => a.Id == id).FirstOrDefault();
        }

        public bool CreateEvento(Evento evento)
        {
            _context.Add(evento);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}