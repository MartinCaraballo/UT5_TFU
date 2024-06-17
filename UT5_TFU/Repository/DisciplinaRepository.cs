using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class DisciplinaRepository
    {
        private DataContext _context;

        public DisciplinaRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Disciplina> GetDisciplinas()
        {
            return _context.Disciplinas.ToList();
        }

        public Disciplina GetDisciplina(int id)
        {
            return _context.Disciplinas.Where(a => a.Id == id).FirstOrDefault();
        }

        public bool CreateDisciplina(Disciplina disciplina)
        {
            _context.Add(disciplina);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}