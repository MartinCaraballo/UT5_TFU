namespace WebApp.Models
{
    public class Modalidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public ICollection<Categoria> Categorias { get; set; }
        
        
    }
}