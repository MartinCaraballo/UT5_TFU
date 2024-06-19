namespace WebApp.Models
{
    public class Juez : Usuario
    {
        public ICollection<Puntuacion> Puntuaciones { get; set; }
        
    }
}