namespace WebApp.Models
{
    public class Categoria
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public LinkedList<Evento> Eventos { get; set; }

    }
}