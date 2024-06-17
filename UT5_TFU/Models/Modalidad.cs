namespace WebApp.Models
{
    public class Modalidad
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public LinkedList<Categoria> Categorias { get; set; }
        
        public Modalidad(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Categorias = new LinkedList<Categoria>();
        }
    }
}