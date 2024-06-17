using Microsoft.EntityFrameworkCore;
using WebApp.Models;

namespace WebApp.Data
{
    public class DataContext(DbContextOptions<DataContext> options) : DbContext(options)
    {
        public DbSet<Atleta> Atletas { get; set; }

        public DbSet<Evento> Eventos { get; set; }

        public DbSet<Categoria> Categorias { get; set; }

        public DbSet<Modalidad> Modalidades { get; set;}
    }
}


