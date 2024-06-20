namespace WebApp.Models
{
    public class Disciplina
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public List<Modalidad> Modalidades { get; set; }

    }
}