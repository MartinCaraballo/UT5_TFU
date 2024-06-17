namespace WebApp.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public LinkedList<Modalidad> Modalidades { get; set; }

        public Disciplina(int id, string nombre)
        {
            Id = id;
            Nombre = nombre;
            Modalidades = new LinkedList<Modalidad>();
        }

    }
}