using WebApp.Data;
using WebApp.Models;

namespace WebApp.Repository
{
    public class CategoriaRepository
    {
        private DataContext _context;

        public CategoriaRepository(DataContext context)
        {
            _context = context;
        }

        public ICollection<Categoria> GetCategorias()
        {
            return _context.Categorias.ToList();
        }

        public Categoria GetCategoria(int id)
        {
            return _context.Categorias.Where(a => a.Id == id).FirstOrDefault();
        }

        public bool CreateCategoria(Categoria categoria)
        {
            _context.Add(categoria);
            return Save();
        }

        public bool Save()
        {
            var saved = _context.SaveChanges();
            return saved > 0 ? true : false;
        }
    }
}