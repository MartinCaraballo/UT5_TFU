namespace WebApp.Models
{
    public class Atleta
    {
        public int Id { get; set; }
        public string Name { get; set; }

        public Atleta(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}


