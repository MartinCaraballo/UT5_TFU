namespace WebApp.Models
{
    public class Atleta
    {
        public int Id { get; }
        public string Name { get; }

        public Atleta(int id, string name)
        {
            Id = id;
            Name = name;
        }
    }
}


