using System;

namespace WebApp.Models
{
    public class Atleta
    {
        public int Id { get; set; }
        public string Nombre { get; set; }
        public DateTime FechaNac { get; set; }
        public string Sexo { get; set; }
        public Atleta(int id, string nombre, DateTime fechaNac, string sexo)
        {
            Id = id;
            Nombre = nombre;
            FechaNac = fechaNac;
            Sexo = sexo;
        }
    }
}


