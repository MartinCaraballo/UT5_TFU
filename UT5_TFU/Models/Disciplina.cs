namespace WebApp.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public LinkedList<Modalidad> Modalidades { get; set; }

    }
}