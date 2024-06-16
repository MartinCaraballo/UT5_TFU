using System;

namespace WebApp.Models
{
    public class Atleta
    {
        public int Id { get; }
        public string Nombre { get; }
        public DateTime FechaNac { get; }
        public string Sexo { get; }
        
        public Atleta(int id, string nombre, DateTime fechaNac, string sexo)
        {
            Id = id;
            Nombre = nombre;
            FechaNac = fechaNac;
            Sexo = sexo;
        }
    }
}


